import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserType } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class UserTypesService {
  private baseUrl = 'https://localhost:7134/api'; 

  constructor(private http: HttpClient) { }

  getUserTypes(): Observable<UserType[]> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });
    
    return this.http.get<UserType[]>(`${this.baseUrl}/UserTypes`, { headers });
  }
}