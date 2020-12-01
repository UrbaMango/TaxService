import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { City } from '../city';

@Injectable({
  providedIn: 'root'
})
export class CityService {

    private citiesUrl = 'http://localhost:59865/api/GetAllCities';
    private rateUrl = 'http://localhost:59865/api/CalculateTax';

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    constructor(private http: HttpClient) { }
    

    getCities(): Observable<City[]> {
        return this.http.get<City[]>(this.citiesUrl)
    }

    getRate(id: number, date: any): any {
        const url = `${this.rateUrl}?id=${id}&date=${date}`;
        console.log(this.http.get<number>(url));
        return this.http.get<any>(url);
    }

}
