import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CadastroPessoaComponent } from '../cadastro-pessoa/cadastro-pessoa.component';

@NgModule({
  declarations: [
    CadastroPessoaComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
  ],
  exports: [
    CadastroPessoaComponent,
  ],
})
export class CadastroPessoasModule {}