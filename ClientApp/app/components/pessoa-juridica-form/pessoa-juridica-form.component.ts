//import { ControlMessageComponent } from './../shared/control-message/control-message.component';
import { PessoaJuridicaFormValidatorService } from './pessoa-juridica-form.validator';
import { UtilsService } from './../utils/utils';
import { ToastyService } from 'ng2-toasty';
import { PessoaJuridicaService } from './../../services/pessoaJuridica.service';
import { ActivatedRoute, Router } from '@angular/router';
import { PessoaJuridica, SavePessoaJuridica } from './../../models/pessoaJuridica';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import {InputMaskModule} from 'primeng/primeng';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';


@Component({
  selector: 'app-pessoa-juridica-form',
  templateUrl: './pessoa-juridica-form.component.html',
  styleUrls: ['./pessoa-juridica-form.component.css']
})
export class PessoaJuridicaFormComponent implements OnInit {
  
  enderecoValido: boolean = false;
  pessoaJuridicaForm : any;
  oldCnpj : any = "";
  pessoaJuridica: SavePessoaJuridica = {
    id: 0,    
    nomeFantasia: '',
    razaoSocial: '',
    cnpj: '',
    endereco: {
      estado: '',
      cidade: '',
      logradouro: ''
    }     
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private pessoaJuridicaService: PessoaJuridicaService,
    private toastyService: ToastyService,
    private formBuilder: FormBuilder) {

      route.params.subscribe(p => {
        this.pessoaJuridica.id = +p['id'] || 0;
        this.oldCnpj = p['cnpj'] || '';
      });   
      this.createValidators();
  }

  ngOnInit() {
    if (this.pessoaJuridica.id){      
      this.pessoaJuridicaService.getPessoaJuridica(this.pessoaJuridica.id).subscribe(data => {     
        if (this.pessoaJuridica.id) {
          this.setPessoaJuridica(data);   
          this.enderecoValido = true;
        }
      }, err => {
        if (err.status == 404)
          this.router.navigate(['/pessoasJuridicas']);
      });
    }
  }

  private setPessoaJuridica(p: PessoaJuridica) {
    this.pessoaJuridica.id = p.id;
    this.pessoaJuridica.nomeFantasia = p.nomeFantasia;
    this.pessoaJuridica.razaoSocial = p.razaoSocial;
    this.pessoaJuridica.cnpj = p.cnpj;    
    this.pessoaJuridica.endereco = p.endereco;    
    this.oldCnpj = p.cnpj;
  } 

  createValidators()
  {
    var group = {
      'nomeFantasia': ['', Validators.required],     
      'razaoSocial': ['', Validators.required],
      'cnpj': ['', [Validators.required,PessoaJuridicaFormValidatorService.cnpjValidator],PessoaJuridicaFormValidatorService.cnpjExistenteValidator(this.pessoaJuridicaService,this.oldCnpj)],
    };

    this.pessoaJuridicaForm = this.formBuilder.group(group);   
  }

  onEnderecoEstadoChange($event){
    this.pessoaJuridica.endereco.estado = $event.estado;
    this.verificaEnderecoValido();
  }

  onEnderecoCidadeChange($event){
    this.pessoaJuridica.endereco.cidade = $event.cidade;
    this.verificaEnderecoValido();
  }

  onEnderecoLogradouroChange($event){
    this.pessoaJuridica.endereco.logradouro = $event.logradouro;
    this.verificaEnderecoValido();
  }

  verificaEnderecoValido()
  {
    this.enderecoValido = (this.pessoaJuridica.endereco.estado != "") && (this.pessoaJuridica.endereco.cidade != "") && (this.pessoaJuridica.endereco.logradouro != "");
  }


  submit() {
    var result$ = (this.pessoaJuridica.id) ? this.pessoaJuridicaService.update(this.pessoaJuridica) : this.pessoaJuridicaService.create(this.pessoaJuridica); 
    result$.subscribe(pessoaJuridica => {
      this.toastyService.success({
        title: 'Successo', 
        msg: 'Salvo com sucesso.',
        theme: 'bootstrap',
        showClose: true,
        timeout: 5000
      });
      this.router.navigate(['/pessoasJuridicas'])
    });
  }

}
