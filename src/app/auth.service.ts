import { Injectable, PLATFORM_ID, Inject } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private authUrl = 'https://localhost:7134/api/Auth';
  private userUrl = 'https://localhost:7134/api/User';

  constructor(private http: HttpClient, @Inject(PLATFORM_ID) private platformId: Object) { }

  login(username: string, password: string): Observable<any> { 
    const url = `${this.authUrl}/login`; 
    const body = { userName: username, password: password };
    return this.http.post<any>(url, body).pipe(
      catchError(this.handleError)
    );
  }

  getMe(token: string): Observable<any> {
    const url = `${this.userUrl}/me`;
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.get<any>(url, { headers }).pipe(
      catchError(this.handleError)
    );
  }
  
  private handleError(error: any) {
    console.error("API Error:", error);
    return throwError(() => error);
  }

  isLoggedIn(): boolean {
    if (isPlatformBrowser(this.platformId)) {
      const token = localStorage.getItem('token');
      return !!token;
    }
    return false;
  }

  getUsername(): string {
    if (isPlatformBrowser(this.platformId)) {
      const token = localStorage.getItem('token');
      if (token) {
        try {
          const decodedToken = JSON.parse(atob(token.split('.')[1]));
          return decodedToken.userName;
        } catch (error) {
          console.error("Error decoding token:", error);
          return '';
        }
      }
    }
    return '';
  }

  logout() {
    if (isPlatformBrowser(this.platformId)) {
      localStorage.removeItem('token');
    }
  }
}