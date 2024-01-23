import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { CadastroUsuarioComponent } from './cadastro-usuario.component';

@NgModule({
  declarations: [CadastroUsuarioComponent],
  imports: [CommonModule, FormsModule],
  exports: [CadastroUsuarioComponent], 
})
export class CadastroUsuarioModule {}