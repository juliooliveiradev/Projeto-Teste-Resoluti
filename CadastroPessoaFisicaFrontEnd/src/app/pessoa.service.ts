import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PessoaService {
  private apiUrl = 'http://localhost:5278/api/pessoaFisica'; 

  constructor(private http: HttpClient) {}

  getPessoas(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  adicionarPessoa(pessoa: any): Observable<any> {
    return this.http.post(this.apiUrl, pessoa);
  }

  editarPessoa(id: number, pessoa: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, pessoa);
  }

  deletarPessoa(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

}
