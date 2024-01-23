// app.module.ts

// app.module.ts

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { CadastroUsuarioComponent } from './cadastro-usuario/cadastro-usuario.component';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      { path: 'cadastro-usuario', component: CadastroUsuarioComponent },
      { path: 'login', component: LoginComponent },
      
    ]),
  ],
  bootstrap: [AppComponent], // Coloque AppComponent aqu
})
export class AppModule {}

