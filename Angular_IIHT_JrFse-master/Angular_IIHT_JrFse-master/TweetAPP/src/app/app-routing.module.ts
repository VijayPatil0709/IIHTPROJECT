import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ForgotpasswordComponent } from './home/forgotpassword/forgotpassword.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ChangepasswordComponent } from './user/changepassword/changepassword.component';
import { PosttweetComponent } from './user/posttweet/posttweet.component';
import { SearchtweetComponent } from './user/searchtweet/searchtweet.component';
import { UserLandingPageComponent } from './user/user-landing-page/user-landing-page.component';
import { ViewtweetsComponent } from './user/viewtweets/viewtweets.component';
import { ViewprofileComponent } from './viewprofile/viewprofile.component';

const routes: Routes = [
  {path:'REGISTER',component:RegisterComponent},
  {path:'HOME',component:HomeComponent},
  {path:'USER',component:UserLandingPageComponent},
    {path:'VIEW-TWEETS',component:ViewtweetsComponent},
    {path:'POST TWEET',component:PosttweetComponent},
    {path:'CHANGEPASSWORD',component:ChangepasswordComponent},
    {path:'FORGOTPASSWORD',component:ForgotpasswordComponent},
    {path:'SEARCH TWEET',component:SearchtweetComponent},
    {path:'VIEW PROFILE',component:ViewprofileComponent},
  {path:'',redirectTo:'HOME',pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes), CommonModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
