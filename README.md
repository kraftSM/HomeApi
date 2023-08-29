# HomeApi -Д/З по Unit 34 С# Developer
- Дано структурированное приложение, в котором, как предполагается, УЖЕ решены вопросы архитектуры приложения и структур данных.
- Задачей является дописатьэто решение в соответсвии с пунктами домашнего задания. Поэтому выбран такой путь:
- - мининимизация изменений в существующем коде
- - новый код должен быть макмально аналогичен уже написанному
- Для ВСЕХ элементов должно быть (в первом приближении) сделано:
- - Сервис просмотра всех элементов данного типа (списком, с передачей GUID каждого элемента)
- - Сервис добавления элементов. При добавлении элемента,его GUID генерится сервером
- - Сервисы удаления и редактирования (обновления) элементов
- - удаление и обновление ВСЕХ элементов порисходит по их GUID. То каким образом из клиенткое приложение этот GUID  вычленяет из полного списка - вне контекста этого задания
- Соответсвенно в решение добавляется
- - Отображение элементов для Room
- - Удаление элементов для Room Device
- - Обновление элементов для Room (для Device уже сделано в предлагаемом решении) 
