import { SavePessoaJuridica } from './../models/pessoaJuridica';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http'; 
import 'rxjs/add/operator/map';
//import { AuthHttp } from "angular2-jwt/angular2-jwt";

@Injectable()
export class PessoaJuridicaService {
  private readonly pessoasJuridicasEndpoint = '/api/pessoasJuridicas';

  constructor(private http: Http) { }

  create(pessoaJuridica) {
    return this.http.post(this.pessoasJuridicasEndpoint, pessoaJuridica)
      .map(res => res.json());
  }

  getPessoaJuridica(id) {
    return this.http.get(this.pessoasJuridicasEndpoint + '/' + id)
      .map(res => res.json());
  }

  getPessoasJuridicas(filter) {
    return this.http.get(this.pessoasJuridicasEndpoint + '?' + this.toQueryString(filter))
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

  update(pessoaJuridica: SavePessoaJuridica) {
    return this.http.put(this.pessoasJuridicasEndpoint + '/' + pessoaJuridica.id, pessoaJuridica)
      .map(res => res.json());
  }

  delete(id) {
    return this.http.delete(this.pessoasJuridicasEndpoint + '/' + id)
      .map(res => res.json());
  }

  checkCnpjNotTaken(cnpjOld,cnpj: string) {    
    return this.http.get(this.pessoasJuridicasEndpoint+'?'+this.toQueryString({Cnpj : cnpj}))
    .map(res => res.json())
    .map(users => {
      if (cnpjOld === cnpj)
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
