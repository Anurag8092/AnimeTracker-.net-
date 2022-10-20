import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { AuthGuard } from './guard/auth-guard.service';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { AdminCreateBookComponent } from './admin-create-book/admin-create-book.component';
import { ForumComponent } from './forum/forum.component';
import { NewDiscussionComponent } from './new-discussion/new-discussion.component';
import { QueryDetailsComponent } from './query-details/query-details.component';
import { RegisterUserComponent } from './register-user/register-user.component';
import { BookComponent } from './book/book.component';
import { FilterBooksPipe } from './filter-books.pipe';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MdbCarouselModule } from 'mdb-angular-ui-kit/carousel';
import { NavbarComponent } from './navbar/navbar.component';


export function getToken(){
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    UserProfileComponent,
    AdminCreateBookComponent,
    ForumComponent,
    NewDiscussionComponent,
    QueryDetailsComponent,
    RegisterUserComponent,
    BookComponent,
    FilterBooksPipe,
    NavbarComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    MatFormFieldModule,
    MdbCarouselModule,

    JwtModule.forRoot({
      config: {
        tokenGetter: getToken,
        allowedDomains: ["localhost:7630"],
        disallowedRoutes: []
      }
    }),
    BrowserAnimationsModule
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
