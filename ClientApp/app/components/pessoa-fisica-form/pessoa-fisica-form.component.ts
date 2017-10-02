import { PessoaFisicaFormValidatorService } from './pessoa-fisica-form.validator';
import { FormBuilder, Validators } from '@angular/forms';
import { ToastyService } from 'ng2-toasty';
import { PessoaFisicaService } from './../../services/pessoaFisica.service';
import { ActivatedRoute, Router } from '@angular/router';
import { SavePessoaFisica, PessoaFisica } from './../../models/pessoaFisica';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-pessoa-fisica-form',
  templateUrl: './pessoa-fisica-form.component.html',
  styleUrls: ['./pessoa-fisica-form.component.css']
})
export class PessoaFisicaFormComponent implements OnInit {

  enderecoValido: boolean = false;
  pessoaFisicaForm : any;
  oldCpf : any = "";
  pessoaFisica: SavePessoaFisica = {
    id: 0,    
    nome: '',
    sobreNome: '',
    cpf: '',
    endereco: {
      estado: '',
      cidade: '',
      logradouro: ''
    }     
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private pessoaFisicaService: PessoaFisicaService,
    private toastyService: ToastyService,
    private formBuilder: FormBuilder) {

      route.params.subscribe(p => {
        this.pessoaFisica.id = +p['id'] || 0;
        this.oldCpf = p['cpf'] || '';
      });   
      this.createValidators();
  }

  ngOnInit() {
    if (this.pessoaFisica.id){      
      this.pessoaFisicaService.getPessoaFisica(this.pessoaFisica.id).subscribe(data => {     
        if (this.pessoaFisica.id) {
          this.setPessoaFisica(data);   
          this.enderecoValido = true;
        }
      }, err => {
        if (err.status == 404)
          this.router.navigate(['/pessoasFisicas']);
      });
    }
  }

  private setPessoaFisica(p: PessoaFisica) {
    this.pessoaFisica.id = p.id;
    this.pessoaFisica.nome = p.nome;
    this.pessoaFisica.sobreNome = p.sobreNome;
    this.pessoaFisica.cpf = p.cpf;    
    this.pessoaFisica.endereco = p.endereco;    
  } 

  createValidators()
  {
    var group = {
      'nome': ['', Validators.required],     
      'sobreNome': ['', Validators.required],
      'cpf': ['', [Validators.required,PessoaFisicaFormValidatorService.cpfValidator],PessoaFisicaFormValidatorService.cpfExistenteValidator(this.pessoaFisicaService,this.oldCpf)],
    };

    this.pessoaFisicaForm = this.formBuilder.group(group);   
  }

  onEnderecoEstadoChange($event){
    this.pessoaFisica.endereco.estado = $event.estado;
    this.verificaEnderecoValido();
  }

  onEnderecoCidadeChange($event){
    this.pessoaFisica.endereco.cidade = $event.cidade;
    this.verificaEnderecoValido();
  }

  onEnderecoLogradouroChange($event){
    this.pessoaFisica.endereco.logradouro = $event.logradouro;
    this.verificaEnderecoValido();
  }

  verificaEnderecoValido()
  {
    this.enderecoValido = (this.pessoaFisica.endereco.estado != "") && (this.pessoaFisica.endereco.cidade != "") && (this.pessoaFisica.endereco.logradouro != "");
  }


  submit() {
    var result$ = (this.pessoaFisica.id) ? this.pessoaFisicaService.update(this.pessoaFisica) : this.pessoaFisicaService.create(this.pessoaFisica); 
    result$.subscribe(pessoaJuridica => {
      this.toastyService.success({
        title: 'Successo', 
        msg: 'Salvo com sucesso.',
        theme: 'bootstrap',
        showClose: true,
        timeout: 5000
      });
      this.router.navigate(['/pessoasFisicas'])
    });
  }

}
