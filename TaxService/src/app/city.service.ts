import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { City } from '../city';

@Injectable({
  providedIn: 'root'
})
export class CityService {

    private citiesUrl = 'http://localhost:59865/api/GetAllCities';
    private rateUrl = 'http://localhost:59865/api/CalculateTax';

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    };
    options = {
        responseType: 'text' as const,
    };

    constructor(private http: HttpClient) { }
    

    getCities(): Observable<City[]> {
        return this.http.get<City[]>(this.citiesUrl)
    }

    getRate(id: number, date: Date, rule: number): Observable<any>{

        const url = `${this.rateUrl}?id=${id}&date=${date}&taxRule=${rule}`;

        console.log(url);

        return this.http.get(url, { responseType: 'text' });

    }

}
