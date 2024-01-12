# Weather Pollution Prediction API

This is a backend API built with .NET Core 6 that integrates weather forecast and air pollution prediction using machine learning. It receives a json file containing historical weather and pollution data, triggers a Python script to create a machine learning model, and provides weather forecasts along with pollution predictions to the frontend.

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [Uploading Historical Data](#uploading-historical-data)
- [Machine Learning Model](#machine-learning-model)


### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/your-repository.git
   cd your-repository
   ```
2. Install .Net 6.0
3. Open project
4. Run in terminal:
```bash
dotnet build
dotnet run
 ```
5. Visit `http://localhost:5000`


### Usage
The Weather Pollution Prediction API allows you to predict pollution levels based on historical weather and air quality data.

### Uploading Historical Data

Submit a POST request to the `/api/Weather` endpoint, providing a list of historical weather conditions and pollution data in the following format:

```json
[
  {
    "Date": "2022-01-01",
    "Temperature": 20.5,
    "Pressure": 1010.2,
    "WindSpeed": 5.0,
    "AirPollution": 15.3,
    "Humidity": 65.0
  },
  // etc
]
```
Example:

```bash
curl -X POST -H "Content-Type: application/json" -d '[{"Date":"2022-01-01","Temperature":20.5,"Pressure":1010.2,"WindSpeed":5.0,"AirPollution":15.3,"Humidity":65.0}]' http://localhost:5000/api/Weather
```

After that request you will recvieve forecast with air pollution based on python model for 7 days

### Machine Learning Model
The API's machine learning model is created by the Python script triggered during the data upload process. The script employs advanced machine learning techniques to predict pollution levels based on historical weather conditions and air quality data.

