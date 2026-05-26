from PregnantHealthRiskApi.app.model.data_record import DataRecord
from pydantic import BaseModel, ConfigDict

class Dataset(BaseModel):
    """
    Модель, которая хранит записи датасета для предсказания.
    """
    Records: list[DataRecord]

    model_config = ConfigDict(
        extra="forbid"
    )
