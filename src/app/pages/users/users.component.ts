import { Component, OnInit } from '@angular/core';
import { from } from 'rxjs';
import { User, UserService, UserType } from '../../services/user.service';
import { error } from 'console';
import { NgFor, NgIf } from '@angular/common';
import { UserTypesService } from '../../services/user-types.service';

@Component({
  selector: 'app-users',
  imports: [NgFor, NgIf],
  templateUrl: './users.component.html',
  styleUrl: './users.component.scss'
})
export class UsersComponent implements OnInit {
  userData: User[] = [];
  userTypes: UserType[] = [];
  loading: boolean = true;

  constructor(private userService: UserService, private userTypesService: UserTypesService) { }

  ngOnInit(): void {
    this.userService.getUsers().subscribe(
      data => {
        this.userData = data;
        this.loading = false;
        this.getUserTypes(); 
      },
      error => {
        console.error('Kullanıcı verileri alınamadı:', error);
        this.loading = false;
      }
    );
  }

  getUserTypes(): void {
    this.userTypesService.getUserTypes().subscribe(
      data => {
        this.userTypes = data;
        this.mapUserTypesToUsers();
      },
      error => {
        console.error('Kullanıcı tipleri alınamadı:', error);
      }
    );
  }

  mapUserTypesToUsers(): void {
    this.userData.forEach(user => {
      const userType = this.userTypes.find(ut => ut.userTypeId === user.userTypeId);
      if (userType) {
        user.userType = userType.userType;
      }
    });
  }
}