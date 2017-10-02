import { SavePessoaFisica } from './../models/pessoaFisica';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http'; 
import 'rxjs/add/operator/map';
//import { AuthHttp } from "angular2-jwt/angular2-jwt";

@Injectable()
export class PessoaFisicaService {
  private readonly pessoasFisicasEndpoint = '/api/pessoasFisicas';

  constructor(private http: Http) { }

  create(pessoaFisica) {
    return this.http.post(this.pessoasFisicasEndpoint, pessoaFisica)
      .map(res => res.json());
  }

  getPessoaFisica(id) {
    return this.http.get(this.pessoasFisicasEndpoint + '/' + id)
      .map(res => res.json());
  }

  getPessoasFisicas(filter) {
    return this.http.get(this.pessoasFisicasEndpoint + '?' + this.toQueryString(filter))
      .map(res => res.json());
  }

  toQueryString(obj) {
    var parts = [];
    for (var property in obj) {
      var value = obj[property];
      if (value != null && value != undefined) 
        parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
    }

    return parts.join('&');
  }

  update(pessoaFisica: SavePessoaFisica) {
    return this.http.put(this.pessoasFisicasEndpoint + '/' + pessoaFisica.id, pessoaFisica)
      .map(res => res.json());
  }

  delete(id) {
    return this.http.delete(this.pessoasFisicasEndpoint + '/' + id)
      .map(res => res.json());
  }

  checkCpfNotTaken(cpfOld,cpf: string) {    
    return this.http.get(this.pessoasFisicasEndpoint+'?'+this.toQueryString({Cpf : cpf}))
    .map(res => res.json())
    .map(users => {
      if (cpfOld === cpf)
        return true;
      else  {
        if (users.totalItems > 0)
          return false;
        else
          return true;  
      }
    });    
  }
}