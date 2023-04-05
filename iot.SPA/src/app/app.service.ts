import {
    HttpClient,
    HttpResponse,
  } from '@angular/common/http';
  import { Injectable } from '@angular/core';
  import { Observable, of } from 'rxjs';
  import { environment } from 'src/environments/environment';
import { Item } from './item.model';
  
  @Injectable({ providedIn: 'root' })
  export class ItemApiService {
    baseUrl: string;
  
    constructor(private http: HttpClient) {
      this.baseUrl = environment.apiUrl;
    }
  
    getAll(): Observable<HttpResponse<Item[]>> {
      return this.http.get<Item[]>(`${this.baseUrl}item`, {
        observe: 'response',
      });
    }
  
  }
  