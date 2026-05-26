"""
    Путь для получения результата предсказания по taskId
"""

from fastapi import APIRouter, HTTPException
from PregnantHealthRiskApi.app.model.status_data.status_data_with_content import StatusDataWithContent
from PregnantHealthRiskApi.app.routes.routes_dependencies import yPrediction

router = APIRouter()

@router.get("/predict/{taskId}",
            summary="Получить результат предсказания по заданному taskId.")
def predict(taskId: str):
    if taskId not in yPrediction:
        raise HTTPException(
            status_code=404,
            detail="taskId is not found."
        )

    if yPrediction[taskId] is None:
        raise HTTPException(
            status_code=425,
            detail="Prediction is not ready yet."
        )

    statusData = {
        "Success" : True,
        "Message" : "Prediction is ready.",
        "Content" : yPrediction[taskId].tolist()
    }

    del yPrediction[taskId]

    return StatusDataWithContent(**statusData)

