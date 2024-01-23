import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly TOKEN_KEY = 'access_token';
  private apiUrl = 'http://localhost:5278' 

  constructor(private http: HttpClient, private jwtHelper: JwtHelperService, private router: Router) {}

  isLoggedIn(): boolean {
    const token = this.getToken();
    return token !== null && !this.isTokenExpired(token);
  }

  login(token: string): void {
    localStorage.setItem(this.TOKEN_KEY, token);
    this.router.navigate(['/lista-pessoa']); 
  }

  logout(): void {
    localStorage.removeItem(this.TOKEN_KEY);
    this.router.navigate(['/login']); 
  }

  private getToken(): string | null {
    return localStorage.getItem(this.TOKEN_KEY);
  }

  private isTokenExpired(token: string): boolean {
    return this.jwtHelper.isTokenExpired(token);
  }

  cadastrarUsuario(usuario: any): Observable<any> {
    const url = `${this.apiUrl}/api/auth/signup`;
    return this.http.post(url, usuario);
  }

  uploadImage(imageData: FormData): Observable<any> {
    const url = `${this.apiUrl}/api/auth/upload`; 
    return this.http.post(url, imageData);
  }

  realizarLogin(credenciais: any): Observable<any> {
    const url = `${this.apiUrl}/api/auth/signin`;
    return this.http.post(url, credenciais);
  }

  obterUsuario(): Observable<any> {
    const url = `${this.apiUrl}/api/auth/user`;
    return this.http.get(url);
  }

  getNomeUsuario(): string {
    const token = localStorage.getItem(this.TOKEN_KEY);

    if (token && !this.jwtHelper.isTokenExpired(token)) {
      const decodedToken = this.jwtHelper.decodeToken(token);
      return decodedToken?.unique_name || '';
    }

    return '';
  }
}
