import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-endereco-form',
  templateUrl: './endereco-form.component.html',
  styleUrls: ['./endereco-form.component.css']
})
export class EnderecoFormComponent implements OnInit {

  @Input() estado: any;
  @Input() cidade: any;
  @Input() logradouro: any;
  @Output() onEstadoChangeOutput : EventEmitter<any> = new EventEmitter<any>();
  @Output() onCidadeChangeOutput : EventEmitter<any> = new EventEmitter<any>();
  @Output() onLogradouroChangeOutput : EventEmitter<any> = new EventEmitter<any>();

  estados: any[] = [
    {estado:"Acre	              ",uf:"AC"},	 
    {estado:"Alagoas	          ",uf:"AL"},	 
    {estado:"Amapá	            ",uf:"AP"},	 
    {estado:"Amazonas	          ",uf:"AM"},	 
    {estado:"Bahia	            ",uf:"BA"},	 
    {estado:"Ceará	            ",uf:"CE"},	 
    {estado:"Distrito Federal	  ",uf:"DF"},	 
    {estado:"Espírito Santo	    ",uf:"ES"},	 
    {estado:"Goiás	            ",uf:"GO"},	 
    {estado:"Maranhão	          ",uf:"MA"},	 
    {estado:"Mato Grosso	      ",uf:"MT"},	 
    {estado:"Mato Grosso do Sul ",uf:"MS"},	 
    {estado:"Minas Gerais	      ",uf:"MG"},	 
    {estado:"Pará	              ",uf:"PA"},	 
    {estado:"Paraíba	          ",uf:"PB"},	 
    {estado:"Paraná	            ",uf:"PR"},	 
    {estado:"Pernambuco	        ",uf:"PE"},	 
    {estado:"Piauí	            ",uf:"PI"},	 
    {estado:"Rio de Janeiro	    ",uf:"RJ"},	 
    {estado:"Rio Grande do Norte",uf:"RN"},	 
    {estado:"Rio Grande do Sul	",uf:"RS"},	 
    {estado:"Rondônia	          ",uf:"RO"},	 
    {estado:"Roraima	          ",uf:"RR"},	 
    {estado:"Santa Catarina	    ",uf:"SC"},	 
    {estado:"São Paulo	        ",uf:"SP"},	 
    {estado:"Sergipe	          ",uf:"SE"},	 
    {estado:"Tocantins	        ",uf:"TO"}
  ]; 

  constructor() { }
  
  ngOnInit() {
  }

  onEstadoChange()
  {
    this.onEstadoChangeOutput.emit({
      estado : this.estado
    });
  }

  onCidadeChange()
  {
    this.onCidadeChangeOutput.emit({
      cidade : this.cidade
    });
  }

  onLogradouroChange()
  {
    this.onLogradouroChangeOutput.emit({
      logradouro : this.logradouro
    });
  }

}
