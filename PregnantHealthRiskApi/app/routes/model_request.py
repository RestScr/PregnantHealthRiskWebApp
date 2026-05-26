"""
    Путь задания запроса для модели.
"""
import uuid
from fastapi import APIRouter, BackgroundTasks
from PregnantHealthRiskApi.app.ai_models.health_risk_classifier import HealthRiskClassifier
from PregnantHealthRiskApi.app.model.dataset import Dataset
from PregnantHealthRiskApi.app.model.status_data.status_data_with_content import StatusDataWithContent
import pandas

from PregnantHealthRiskApi.app.routes.routes_dependencies import yPrediction

router = APIRouter()


def ConvertIntoDataframe(dataset: Dataset) -> pandas.DataFrame:
    """
        Функция преобразования датасета из модели pydantic
    :param dataset:
    :return pandas.DataFrame:
    """
    output = pandas.DataFrame([row.model_dump() for row in dataset.Records])
    return output


async def CalculatePredictions(taskId : str, dataset : Dataset):
    """
    Вычислить предсказания.
    :param taskId:
    :param dataset:
    :return:
    """

    X = ConvertIntoDataframe(dataset)
    X["BPDelta"] = X["SystolicBP"] - X["DiastolicBP"]
    yPrediction[taskId] = HealthRiskClassifier.Instance().predict(X)


@router.post("/predict",
             summary="Отправка датасета и получение предсказаний модели.")
def predict(dataset : Dataset, backgroundTasks: BackgroundTasks):
    """
        Запрос с подачей датасета на предсказание для модели
    :param dataset:
    :param backgroundTasks:
    :return:
    """
    taskId = str(uuid.uuid4())
    backgroundTasks.add_task(
        CalculatePredictions,
        taskId=taskId,
        dataset=dataset
    )
    statusData = {
        "Success": True,
        "Message": "Received data for prediction...",
        "Content": taskId,
    }

    return StatusDataWithContent(**statusData)
