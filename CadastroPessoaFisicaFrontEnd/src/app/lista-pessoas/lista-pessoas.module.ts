import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; // Certifique-se de importar FormsModule

import { ListaPessoasComponent } from './lista-pessoas.component';

@NgModule({
  declarations: [ListaPessoasComponent],
  imports: [CommonModule, FormsModule], 
})
export class ListaPessoasModule {}