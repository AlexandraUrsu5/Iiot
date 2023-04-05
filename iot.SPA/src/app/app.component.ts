import { Component, OnInit } from '@angular/core';
import { ItemApiService } from './app.service';
import { Item } from './item.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'myDrone';
  items: Item[] = [];
  displayedColumns: string[] = ['no', 'date','buttonState', 'led', 'tone'];
  constructor(
    private api: ItemApiService
  ) {}
  ngOnInit(): void {
    this.api.getAll().subscribe({
      next: (resp) => {
        console.log(resp.body);
        if (resp.body) {
          this.items = resp.body;
        } 
        
      }
    });
  }

  blabla(): void{
    console.log(this.items);
  }
}
