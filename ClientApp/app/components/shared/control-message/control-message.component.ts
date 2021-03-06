import { IValidatorService } from './../../../services/validator.service';
import { Component, OnInit, Input, Inject } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'control-messages',
  template: `<div class="alert alert-danger" *ngIf="errorMessage !== null">{{errorMessage}}</div>` ,
})
export class ControlMessageComponent{

  @Input() control: FormControl;  
  
  constructor(@Inject('IValidatorService') private validationService :IValidatorService) { }
  
  get errorMessage() {
     for (let propertyName in this.control.errors) {
      if (this.control.errors.hasOwnProperty(propertyName) && this.control.touched) {
        return this.validationService.getValidatorErrorMessage(propertyName, this.control.errors[propertyName]);
      }
    }
    return null;
  }
}
