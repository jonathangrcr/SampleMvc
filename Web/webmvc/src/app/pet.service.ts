import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable, Subject} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class PetService {
  private baseUrl = "api";

  public pets$ = this.getPets();
  constructor(private httpClient: HttpClient) { }

  private getPets(): Observable<string[]> {
    return this.httpClient.get<string[]>(`${this.baseUrl}/pet`, { responseType: 'json' });
  }
}
