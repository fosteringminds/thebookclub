import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from '../models/book';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) { }

  getUserSubscriptions(userId?: number, token?: string) {
    let headers = new HttpHeaders();
    headers = headers.set('Authorization', token || '');
    return this.http.get<Book[]>(`${environment.apiUrl}/api/user/getusersubscriptions/${userId}`, {headers: headers});
  }

  savesubscription(userId?: number, bookId?: number, isSubscribed?: boolean, token?: string) {
    let headers = new HttpHeaders();
    headers = headers.set('Authorization', token || '');
    return this.http.get<Book[]>(`${environment.apiUrl}/api/user/savesubscription/${userId}/${bookId}/${isSubscribed}`, {headers: headers});
  }
}
