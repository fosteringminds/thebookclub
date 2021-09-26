import { AuthenticationService } from './../services/authentication.service';
import { BookService } from './../services/book.service';
import { Component, OnInit } from '@angular/core';
import { Book } from '../models/book';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  public bookList: Book[];
  constructor(private bookService: BookService,private authenticationService: AuthenticationService) {
    this.bookList = [];
   }

  ngOnInit(): void {
    console.log(this.authenticationService.currentUserValue.token);
    this.bookService.getUserSubscriptions(this.authenticationService.currentUserValue.id, this.authenticationService.currentUserValue.token).subscribe((res)=>{
      this.bookList = [...res];
    });
  }

  changeSubscription(book: Book) {
    this.bookService.savesubscription(this.authenticationService.currentUserValue.id,book.id,book.isSubscribed,this.authenticationService.currentUserValue.token).subscribe((res)=> {
      this.bookList = [...res];
    });
  }

}
