"""
    Путь задания запроса для модели.
"""
from fastapi import APIRouter
from app.model.dataset import Dataset
from app.ai_models.health_risk_classifier import HealthRiskClassifier
import numpy
import pandas
import asyncio

router = APIRouter()

async def CalculatePredictions(dataset : Dataset) -> numpy.array:
    dataset = pandas.DataFrame.from_records(
        dataset.Records
    )
    yPred = HealthRiskClassifier.Instance().predict(dataset)

    yield yPred


@router.post("/predict")
def predict(dataset : Dataset):
    statusData = {
        "success": True,
        "message": "Calculated predictions.",
        "output": CalculatePredictions(dataset)
    }

    return statusData

