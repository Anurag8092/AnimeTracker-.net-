import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminCreateBookComponent } from './admin-create-book/admin-create-book.component';
import { BookComponent } from './book/book.component';
import { ForumComponent } from './forum/forum.component';
import { AuthGuard } from './guard/auth-guard.service';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { NewDiscussionComponent } from './new-discussion/new-discussion.component';
import { QueryDetailsComponent } from './query-details/query-details.component';
import { RegisterUserComponent } from './register-user/register-user.component';
import { UserProfileComponent } from './user-profile/user-profile.component';

const routes: Routes = [
  {path: "login", component: LoginComponent},
  {path: "signup", component: RegisterUserComponent},
  {path: "", component: HomeComponent},
  {path: "user-profile/:id", component: UserProfileComponent, canActivate: [AuthGuard]},
  {path: "admin", component: AdminCreateBookComponent, canActivate: [AuthGuard]},
  {path: "forum", component: ForumComponent},
  {path: "newQuery", component: NewDiscussionComponent, canActivate: [AuthGuard]},
  {path: "query/:id", component: QueryDetailsComponent},
  {path: "book/:id", component: BookComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
