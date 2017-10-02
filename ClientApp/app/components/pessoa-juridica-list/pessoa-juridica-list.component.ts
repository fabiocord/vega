import { PessoaJuridicaService } from './../../services/pessoaJuridica.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-pessoa-juridica-list',
  templateUrl: './pessoa-juridica-list.component.html',
  styleUrls: ['./pessoa-juridica-list.component.css']
})
export class PessoaJuridicaListComponent implements OnInit {

  private readonly PAGE_SIZE = 3; 
  
    queryFilter: any = {};
    queryResult: any = {};
    nomeFantasia: any;
    query: any = {
      pageSize: this.PAGE_SIZE
    };
    columns = [
      { title: 'Id' },
      { title: 'Nome Fantasia', key: 'nomeFantasia', isSortable: true },
      { title: 'Razão Social', key: 'razaoSocial', isSortable: true },
      { title: 'CNPJ', key: 'cnpj', isSortable: true },
      { title: 'Estado', key: 'estado', isSortable: true },
      { title: 'Cidade', key: 'cidade', isSortable: true },
      { title: 'Logradouro', key: 'logradouro', isSortable: true },
      { }
    ];
  
    constructor(private pessoaJuridicaService: PessoaJuridicaService) { }
  
    ngOnInit() { 
      this.populateFilterFromServer();  
      this.populatePessoasJuridicas();      
    }
  
    private populateFilterFromServer() {
      this.pessoaJuridicaService.getPessoasJuridicas(this.query)
      .subscribe(result => this.queryFilter = result);
    }

    private populatePessoasJuridicas() {
      this.pessoaJuridicaService.getPessoasJuridicas(this.query)
        .subscribe(result => this.queryResult = result);
    }
  
    onFilterChange() {
      this.query.page = 1; 
      this.populatePessoasJuridicas();
    }
  
    resetFilter() {
      this.query = {
        page: 1,
        pageSize: this.PAGE_SIZE
      };
      this.populatePessoasJuridicas();
    }
  
    sortBy(columnName) {
      if (this.query.sortBy === columnName) {
        this.query.isSortAscending = !this.query.isSortAscending; 
      } else {
        this.query.sortBy = columnName;
        this.query.isSortAscending = true;
      }
      this.populatePessoasJuridicas();
    }
  
    onPageChange(page) {
      this.query.page = page; 
      this.populatePessoasJuridicas();
    }
}
