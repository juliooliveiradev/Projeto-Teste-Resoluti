import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { PessoaService } from '../pessoa.service';

@Component({
  selector: 'app-lista-pessoas',
  templateUrl: './lista-pessoas.component.html',
  styleUrls: ['./lista-pessoas.component.css']
})
export class ListaPessoasComponent implements OnInit {
  username = '';  
  termoPesquisa = '';
  pessoas: any[] = [];

  constructor(private authService: AuthService, private pessoaService: PessoaService, private router: Router) {}

  ngOnInit(): void {
    // Obtenha o nome do usuário ao inicializar o componente
    this.username = this.authService.getNomeUsuario();
    
    // Carregue a lista de pessoas ao inicializar o componente
    this.carregarListaPessoas();
  }

  carregarListaPessoas(): void {
    // Use seu serviço de pessoa para obter a lista de pessoas
    this.pessoaService.getPessoas().subscribe(
      (pessoas) => {
        this.pessoas = pessoas;
      },
      (erro) => {
        console.error('Erro ao carregar lista de pessoas', erro);
      }
    );
  }

  sair(): void {
    // Chame o método de logout do seu serviço de autenticação
    this.authService.logout();
    
    // Redirecione para a página de login
    this.router.navigate(['/login']);
  }

  redirecionarParaCadastro(): void {
    // Redirecione para a página de cadastro de pessoa
    this.router.navigate(['/cadastro-pessoa']);
  }

  deletarPessoa(id: number): void {
    // Use seu serviço de pessoa para deletar a pessoa pelo ID
    this.pessoaService.deletarPessoa(id).subscribe(
      () => {
        console.log('Pessoa deletada com sucesso!');
        // Recarregue a lista após a exclusão
        this.carregarListaPessoas();
      },
      (erro) => {
        console.error('Erro ao deletar pessoa', erro);
      }
    );
  }
}

