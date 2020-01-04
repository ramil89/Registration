import { Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

export abstract class BaseApiService {

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  protected get<T>(relativeUrl: string): Observable<T> {
    return this.http.get<T>(this.baseUrl + relativeUrl);
  }

  protected post(relativeUrl: string, data: any) {
    return this.http.post(this.baseUrl + relativeUrl, data);
  }
}
