import { Injectable, Inject } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from './auth.service';
import { isPlatformBrowser } from '@angular/common';
import { PLATFORM_ID } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(
    private authService: AuthService,
    private router: Router,
    @Inject(PLATFORM_ID) private platformId: Object
  ) {}

  canActivate(): boolean {
    if (isPlatformBrowser(this.platformId)) { 
      const token = localStorage.getItem('token'); // Token'ı direkt kontrol et
      if (token && this.authService.isLoggedIn()) {
        return true;
      } else {
        this.router.navigate(['/login']); 
        return false; 
      }
    } else { 
      return false; 
    }
  }
}
