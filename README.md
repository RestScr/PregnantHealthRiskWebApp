# PregnantHealthRiskWebApp
Простейшее приложение с API по определению уровня риска здоровья беременной с использованием простой классификационной модели ИИ.

# Описание
Данное приложение имеет два компонента: API и мини-приложение по эксплуатации API.

# Задача
Данное приложение решает задачу классификации риска здоровья беременной.

## Проблема
Есть параметры здоровья беременной женщины:
- `Age` — возраст беременной.
- `SystolicBP` — верхнее (систолическое) артериальное давление.
- `DiastolicBP` — нижнее (диастолическое) артериальное давление.
- `BS` — уровень глюкозы в крови.
- `BodyTemp` — температура тела.
- `HeartRate` — частота сердечных сокращений.

По данным необходимо определить, какой риск (Low, Medium или High) соответствует здоровью женщины.

## Используемая модель
Используется модель CatboostClassifier.

## Структура API-сервиса
Сам сервис написан с помощью FastAPI с использованием библиотеки валидации json-структур PyDantic.
```
app
|
|   main.py
|   
+---ai_models
|   |   health_risk_classifier.py
|   |   
|   +---ai_dependencies
|   |   __init__.py
|   |           
|   +---files
|       health_risk_classifier.cbm
|           
+---dependencies
|      config.py
|      __init__.py
|           
+---model
|   |   dataset.py
|   |   data_record.py
|   |   
|   +---status_data
|         status_data.py
|         status_data_with_content.py
|           
+---routes
   |   home.py
   |   model_get_prediction.py
   |   model_request.py
   |   
   +---routes_dependencies
       |  __init__.py   
```
- `main.py` - Точка входа в API
- `ai_models` - Папка с классами ИИ моделей
- `dependencies` - Зависимости проекта
- `model` - Модели pydantic
- `routes` - API маршруты

- `files` - Папка с файлами для ИИ-моделей
- `status_data` - Папка с двумя моделями pydantic, описывающие стандартные ответы на запросы API

# Иструкции по установке:
## API
1. Скопируйте репозиторий в папку (Например, в PregnantHealthRiskClassifier).
   ```powershell
   git clone https://github.com/RestScr/PregnantHealthRiskWebApp.git
   ```
2. В консоли с помощью `cd` зайдите в целевую папку, а затем зайдите в папку с API
   ```powershell
   cd <Папка с репозиторием>/PregnantHealthRiskApi
   ```
3. Пропишите в консоли команду для создания виртуального окружения
   ```powershell
   python -m venv .venv
   ```
4.  Далее (на Windows) введите команду для входа в виртуальное окружение
    ```powershell
    . .venv/Scripts/activate
    ```
5. Далее установите все необходимые пакеты, указанные в requirements.txt
   ```powershell
   python -m pip install -r requirements.txt
   ```
6. После установки всех пакетов, запустите файл main.py в консоли для проверки установки
   ```powershell
   python app/main.py
   ```

# Пример эксплуатации
## Для API:
## POST-запросы
```
/predict - Послать данные с предсказанием
```
- Тело запроса:
```json
{
  "Records": [
    {
      "Age": 130,
      "SystolicBP": 0,
      "DiastolicBP": 0,
      "BS": 0,
      "BodyTemp": 0,
      "HeartRate": 0
    }
  ]
}
```
- `"Records"` - Массив данных
- `"Age"` - Возраст пациентки
- `"SystolicBP"` - Систоилческое давление
- `"DiastolicBP"` - Диастолическое давление
- `"BS"` - Уровень сахара в крови (в %)
- `"BodyTemp"` - Температура тела (в фаренгейтах)
- `"HeartRate"` - Пульс

#### Пример успешного ответа
```json
{
  "Success": true,
  "Message": "Received data for prediction...",
  "Content": "a56e1541-4b97-4a0e-bfba-0603aece2107"
}
```

В случае ошибки (валидации, т. е. неправильная структура или одно из значений будет меньше нуля) высвечивается подобная ошибка:
```json
{
  "detail": [
    {
      "type": "greater_than_equal",
      "loc": [
        "body",
        "Records",
        0,
        "SystolicBP"
      ],
      "msg": "Input should be greater than or equal to 0",
      "input": -1,
      "ctx": {
        "ge": 0
      }
    }
  ]
}
```
  
## GET-запросы
```
/docs - страница с документацией
```
--------
```
/predict/<taskID> - получить предсказание по выданному ID
```
taskID - идентификатор процесса, выдаваемый API при посылании POST-запроса с данными для предсказания
#### Пример запроса
```
127.0.0.1:8000/predict/a56e1541-4b97-4a0e-bfba-0603aece2107
```
#### Пример успешного ответа
```json
{
  "Success": true,
  "Message": "Prediction is ready.",
  "Content": [
    [
      0
    ]
  ]
}
```
В качестве ответа посылается json-структура, в которой предсказания на переданные данные перечисляются в списке "Content" в соответствующем порядке, в котором были переданы данные.
