import { Component } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-cadastro-usuario',
  templateUrl: './cadastro-usuario.component.html',
  styleUrls: ['./cadastro-usuario.component.css'],
})
export class CadastroUsuarioComponent {
  userName: string = ''; 
  email: string = ''; 
  telefone: string = ''; 
  senha: string = '';
  imagePath: string = ''; 

  constructor(private cadastroUsuarioService: AuthService) {}

  cadastrarUsuario() {
    const usuario = {
      userName: this.userName,
      email: this.email,
      telefone: this.telefone,
      senha: this.senha,
      imagePath: this.imagePath
    };

    this.cadastroUsuarioService.cadastrarUsuario(usuario).subscribe(
      (response) => {
        // Lógica para tratamento de sucesso
        console.log('Usuário cadastrado:', response);
      },
      (error) => {
        // Lógica para tratamento de erro
        console.error('Erro ao cadastrar usuário:', error);
      }
    );
  }

  onFileSelected(event: any) {
    const file: File = event.target.files[0];

    if (file) {
      const reader = new FileReader();

      reader.onload = (e: any) => {
        // Manipular a imagem aqui
        const base64Image: string = e.target.result;
        this.saveImageInBackend(base64Image);
      };

      reader.readAsDataURL(file);
    } else {
      console.error('Nenhum arquivo selecionado.');
    }
  }

  private saveImageInBackend(base64Image: string) {
    // Crie um FormData para enviar a imagem como um arquivo para a API de backend
    const formData = new FormData();
    formData.append('image', base64Image);
  
    // Chame a API de backend para salvar a imagem
    this.cadastroUsuarioService.uploadImage(formData).subscribe(
      (response) => {
        // Atualize this.imagePath com o caminho retornado pela API
        this.imagePath = response.imagePath;
  
        // Adicione lógica adicional se necessário
      },
      (error) => {
        console.error('Erro ao fazer upload da imagem:', error);
      }
    );
  }
  
}

