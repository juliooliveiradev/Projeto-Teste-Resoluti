// login.component.ts
import { Component } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  mensagemErro: string | null = null;

  constructor(private authService: AuthService, private router: Router) {}

  loginUsuario(dadosFormulario: any): void {
    this.authService.realizarLogin(dadosFormulario).subscribe(
      (resposta) => {
        console.log('Usuário autenticado com sucesso!', resposta);
        // Redirecione para a próxima página (lista-pessoas)
        this.router.navigate(['/lista-pessoas']);
      },
      (erro) => {
        console.error('Erro ao autenticar usuário', erro);
        // Exiba a mensagem de erro para o usuário
        this.mensagemErro = 'Email ou senha inválidos';
      }
    );
  }
}
