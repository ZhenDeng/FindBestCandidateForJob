import { Component, OnInit } from '@angular/core';
import { MatchService } from '../services/match.service';
import { Job } from '../models/job';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public jobs: Job[];
  constructor(private servie: MatchService) {}

  ngOnInit(): void {
    this.servie.GetMatcher().subscribe((res: Job[]) => {
      if (res) {
        this.jobs = res;
      }
    });
  }
}
