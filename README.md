Use swagger to test the WebAPI:
https://localhost:7139/swagger/index.html

WebAPI accepts data in JSON, Fx.

```json
{
  "vehicleTypeName": "car",
  "dates": [
    "2013-01-14 21:00:00",
    "2013-01-15 21:00:00",
    "2013-02-07 06:23:27",
    "2013-02-07 15:27:00",
    "2013-02-08 06:27:00",
    "2013-02-08 06:20:27",
    "2013-02-08 14:35:00",
    "2013-02-08 15:29:00",
    "2013-02-08 15:47:00",
    "2013-02-08 16:01:00",
    "2013-02-08 16:48:00",
    "2013-02-08 17:49:00",
    "2013-02-08 18:29:00",
    "2013-02-08 18:35:00",
    "2013-03-26 14:25:00",
    "2013-03-28 14:07:27"
  ]
}
```

Tax fees are read from a JSON file (taxfees.json)
Start time and end time are in text format due to missing TimeOnly JSON converter (there was no time to write one self).
