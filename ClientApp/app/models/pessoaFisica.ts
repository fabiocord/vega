import { Endereco } from './endereco';

export interface PessoaFisica {
    id: number;
    nome: string;
    sobreNome: string;
    cpf: string;
    endereco: Endereco;
  }

  export interface SavePessoaFisica {
    id: number;
    nome: string;
    sobreNome: string;
    cpf: string;
    endereco: Endereco;
  }
