import { Endereco } from './endereco';

export interface PessoaJuridica {
    id: number;
    nomeFantasia: string;
    razaoSocial: string;
    cnpj: string;
    endereco: Endereco;
  }

  export interface SavePessoaJuridica {
    id: number;
    nomeFantasia: string;
    razaoSocial: string;
    cnpj: string;
    endereco: Endereco;
  }