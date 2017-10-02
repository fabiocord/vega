import { UtilsService } from './../utils/utils';
import { Injectable } from '@angular/core';
import { IValidatorService } from './../../services/validator.service';
import { PessoaJuridicaService } from './../../services/pessoaJuridica.service';
import { AbstractControl } from '@angular/forms';
@Injectable()
export class PessoaJuridicaFormValidatorService implements IValidatorService {
    
    
    constructor() {               
    }


    getValidatorErrorMessage(validatorName: string, validatorValue?: any) {
        let config = {
            'required': 'Preenchimento obrigatório',
            'invalidCNPJ': 'Nº do CNPJ inválido',
            'invalidCNPJExistente': 'CNPJ já utilizado',           
            'minlength': `Tamanho mínimo ${validatorValue.requiredLength} caracteres`
        };

        return config[validatorName];
    }

    static cnpjValidator(control) {
        if(!UtilsService.verificaCnpjValido(control.value))
            return {'invalidCNPJ': true};
        else        
            return null;    
    }
    
    static cnpjExistenteValidator(userService : PessoaJuridicaService, cnpjOld: string = "") {         
        return (control: AbstractControl) => {                        
            return userService.checkCnpjNotTaken(cnpjOld,control.value).map(res => {
                return res ? null : {'invalidCNPJExistente': true};                
            });            
        }
    }


}