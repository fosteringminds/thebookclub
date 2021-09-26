import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  register(emailAddress: string, firstName: string, lastName: string, password: string){
    return this.http.post<any>(`${environment.apiUrl}/api/user/register`, { emailAddress, firstName, lastName, password });
  }
}
