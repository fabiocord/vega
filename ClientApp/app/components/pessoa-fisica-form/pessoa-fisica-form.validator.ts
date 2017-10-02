import { PessoaFisicaService } from './../../services/pessoaFisica.service';
import { UtilsService } from './../utils/utils';
import { Injectable } from '@angular/core';
import { IValidatorService } from './../../services/validator.service';

import { AbstractControl } from '@angular/forms';
@Injectable()
export class PessoaFisicaFormValidatorService implements IValidatorService {
    
    
    constructor() {               
    }


    getValidatorErrorMessage(validatorName: string, validatorValue?: any) {
        let config = {
            'required': 'Preenchimento obrigatório',
            'invalidCPF': 'Nº do CPF inválido',
            'invalidCPFExistente': 'CPF já utilizado',           
            'minlength': `Tamanho mínimo ${validatorValue.requiredLength} caracteres`
        };

        return config[validatorName];
    }

    static cpfValidator(control) {
        if(!UtilsService.verificaCpfValido(control.value))
            return {'invalidCPF': true};
        else        
            return null;    
    }
    
    static cpfExistenteValidator(pessoaFisicaService : PessoaFisicaService, cpfOld: string = "") {         
        return (control: AbstractControl) => {                        
            return pessoaFisicaService.checkCpfNotTaken(cpfOld,control.value).map(res => {
                return res ? null : {'invalidCPFExistente': true};                
            });            
        }
    }


}