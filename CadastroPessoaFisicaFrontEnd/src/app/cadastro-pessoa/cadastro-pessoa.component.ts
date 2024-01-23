import { Component } from '@angular/core';
import { PessoaService } from '../pessoa.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cadastro-pessoa',
  templateUrl: './cadastro-pessoa.component.html',
  styleUrls: ['./cadastro-pessoa.component.css'],
})
export class CadastroPessoaComponent {
  constructor(private pessoaService: PessoaService,private router: Router) {}

  
  estadosBrasileiros = ['AC', 'AL', 'AM', 'AP', 'BA', 'CE', 'DF', 'ES', 'GO', 'MA', 'MG', 'MS', 'MT', 'PA', 'PB', 'PE', 'PI', 'PR', 'RJ', 'RN', 'RO', 'RR', 'RS', 'SC', 'SE', 'SP', 'TO'];
  
  // Modelo para os dados do formulário
  nome: string = '';
  sobrenome: string = '';
  dataNascimento: Date | null = null;
  email: string = '';
  cpf: string = '';
  rg: string = '';
  estadoSelecionado: string = '';

  enderecos: any[] = [{ logradouro: '', numero: '', cep: '',complemento: '', cidade: '', estadoSelecionado : this.estadoSelecionado  }];
  contatos: any[] = [{ nome: '', contato: '', tipoContato: 'Email' }];

  // Adiciona um novo endereço ao array
  adicionarEndereco() {
    this.enderecos.push({ logradouro: '', numero: '', cep: '' });
  }

  // Remove o endereço no índice especificado
  removerEndereco(index: number) {
    this.enderecos.splice(index, 1);
  }

  // Adiciona um novo contato ao array
  adicionarContato() {
    this.contatos.push({ nome: '', contato: '', tipoContato: 'Email' });
  }

  // Remove o contato no índice especificado
  removerContato(index: number) {
    this.contatos.splice(index, 1);
  }

  // Método para cadastrar a pessoa física (a implementação depende do seu backend)
  cadastrarPessoaFisica() {
    // Lógica para enviar os dados para o backend e realizar o cadastro
    const pessoa =  {
      nome: this.nome,
      sobrenome: this.sobrenome,
      dataNascimento: this.dataNascimento,
      enderecos: this.enderecos,
      contatos: this.contatos,
    };

    // Chamar o método do serviço para cadastrar pessoa
    this.pessoaService.adicionarPessoa(pessoa)
      .subscribe(
        response => {
          // Tratar a resposta do servidor, se necessário
          console.log('Resposta do servidor:', response);
          this.router.navigate(['/lista-pessoas']);
        },
        error => {
          // Tratar erros, se houver
          console.error('Erro ao cadastrar pessoa:', error);
        }
      );
}
}
