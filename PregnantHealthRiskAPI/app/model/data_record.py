from pydantic import BaseModel, Field, ConfigDict

class DataRecord(BaseModel):
    """
    Класс одной записи из датасета.
    """
    Age: int = Field(ge=0, le=130)
    SystolicBP : int = Field(ge=0)
    DiastolicBP : int = Field(ge=0)
    BS : float = Field(ge=0)
    BodyTemp : float = Field(ge=0)
    HeartRate : int = Field(ge=0)

    model_config = ConfigDict(
        extra="forbid"
    )
