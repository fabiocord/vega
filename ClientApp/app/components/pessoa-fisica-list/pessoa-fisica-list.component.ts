import { PessoaFisicaService } from './../../services/pessoaFisica.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-pessoa-fisica-list',
  templateUrl: './pessoa-fisica-list.component.html',
  styleUrls: ['./pessoa-fisica-list.component.css']
})
export class PessoaFisicaListComponent implements OnInit {

  private readonly PAGE_SIZE = 3; 
  
    queryFilter: any = {};
    queryResult: any = {};
    nome: any;
    query: any = {
      pageSize: this.PAGE_SIZE
    };
    columns = [
      { title: 'Id' },
      { title: 'Nome', key: 'nome', isSortable: true },
      { title: 'Sobrenome', key: 'sobreNome', isSortable: true },
      { title: 'CPF', key: 'cpf', isSortable: true },
      { title: 'Estado', key: 'estado', isSortable: true },
      { title: 'Cidade', key: 'cidade', isSortable: true },
      { title: 'Logradouro', key: 'logradouro', isSortable: true },
      { }
    ];
  
    constructor(private pessoaFisicaService: PessoaFisicaService) { }
  
    ngOnInit() { 
      this.populateFilterFromServer();  
      this.populatePessoasFisicas();      
    }
  
    private populateFilterFromServer() {
      this.pessoaFisicaService.getPessoasFisicas(this.query)
      .subscribe(result => this.queryFilter = result);
    }

    private populatePessoasFisicas() {
      this.pessoaFisicaService.getPessoasFisicas(this.query)
        .subscribe(result => this.queryResult = result);
    }
  
    onFilterChange() {
      this.query.page = 1; 
      this.populatePessoasFisicas();
    }
  
    resetFilter() {
      this.query = {
        page: 1,
        pageSize: this.PAGE_SIZE
      };
      this.populatePessoasFisicas();
    }
  
    sortBy(columnName) {
      if (this.query.sortBy === columnName) {
        this.query.isSortAscending = !this.query.isSortAscending; 
      } else {
        this.query.sortBy = columnName;
        this.query.isSortAscending = true;
      }
      this.populatePessoasFisicas();
    }
  
    onPageChange(page) {
      this.query.page = page; 
      this.populatePessoasFisicas();
    }
}
