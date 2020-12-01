import { Component, OnInit } from '@angular/core';

import { Http } from '@angular/http'
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { City } from '../city';
import { CityService } from './city.service';



@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

    cities: City[];

    selectedCity: City;

    result: Number;

    onSelect(city: City): void {
        this.selectedCity = city;
    }

    myFunc(num1) {
        this.cityService.getRate(this.selectedCity.id, num1).subscribe(this.result);
        console.log(this.result);
    }

    constructor(private cityService: CityService) { }


    ngOnInit() {
        this.getCities();
    }

    getCities(): void {
        this.cityService.getCities()
            .subscribe(cities => this.cities = cities);
        console.log(this.cities);
    }

}
