import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


export interface User{
    email: string;
    userName: string;
    firstName: string;
    lastName: string;
    userTypeId: number; 
    userType?: string;
}

export interface UserType{
  userType: string;
  userTypeId: number;
}

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private baseUrl = 'https://localhost:7134/api';

  constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]> {
    const token = localStorage.getItem('token');

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}` 
    });

    return this.http.get<User[]>(`${this.baseUrl}/User/all`, { headers });
  }
}