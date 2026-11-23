<div align="center">

# Universidad Tecnológica de Panamá
**Facultad de Ingeniería en Sistemas Computacionales · Campus Víctor Levi Sasso**

## Laboratorio: Temas Varios
Repaso del CRUD, Inyección SQL, Consultas Parametrizadas, Métodos Sobrecargados, Recursividad y Frecuencias

</div>

| | |
|---|---|
| **Materia** | Herramientas de la Programación Aplicada III (.NET) |
| **Instructora** | Ing. Irina Fong |
| **Grupo** | 1IL133 |
| **Semestre** | II Semestre 2026 |
| **Módulo** | IV: Acceso a Base de Datos – Aplicaciones en Capas |
| **Integrante(s)** | _[Nombre y cédula]_ |
| **Fecha de entrega** | _[DD de mes de 2026]_ |

---

## Tecnologías utilizadas

| Herramienta | Versión |
|---|---|
| Lenguaje | C# |
| SDK | .NET 10.0 (`net10.0`) |
| IDE | Visual Studio 2026 |
| Base de datos (Problema 1) | MySQL |
| Tipo de proyecto | Aplicación de consola |

Para comprobar la versión del SDK instalada:

```bash
dotnet --version
```

---

## Estructura del repositorio

```text
Temas varios/
├── Consultas SQL/        Problema 1: consultas SQL (archivo .sql)
├── Diccionarios/         Problema 2: armado de INSERT / UPDATE con parámetros
├── SobreCargados/        Problema 3: métodos sobrecargados
├── Factorial/            Problema 4: recursividad (factorial)
├── Frecuencias/          Problema 5: conteo de frecuencias
└── README.md
```

Cada problema de C# es una solución independiente (`.slnx`) con su propio proyecto de consola.

---

## Guía de instalación y uso

### 1. Clonar el repositorio

```bash
git clone <URL-DEL-REPOSITORIO>
cd "Temas varios"
```

### 2. Abrir la solución

Entre a la carpeta del problema y abra el archivo `.slnx` con Visual Studio. Por ejemplo, `Factorial/Factorial/Factorial.slnx`.

### 3. Restaurar dependencias y ejecutar

Desde la carpeta que contiene el `.csproj` del problema:

```bash
dotnet restore
dotnet run
```

También se puede ejecutar desde Visual Studio con **F5** o **Ctrl + F5**.

---

## Problema 1: Consultas SQL

**Carpeta:** `Consultas SQL/Consultas SQL.sql`

El script trabaja sobre la base de datos `productosdb`. Crea la tabla `permisos` con los campos de usuario, contraseña, correo y módulos, inserta registros de prueba y ejecuta tres consultas:

| # | Consulta | Qué demuestra |
|---|---|---|
| 1 | `WHERE Usuario = '' OR '1'='1' AND Contrasena = '' OR '1'='1'` | Inyección por condición siempre verdadera: devuelve todos los registros sin conocer usuario ni contraseña. |
| 2 | `WHERE Usuario = 'root'; -- ' AND password = ...` | Inyección por comentario: el `--` anula el resto de la condición. |
| 3 | `WHERE id = 1 - SLEEP(15)` | Inyección basada en tiempo: la consulta tarda 15 segundos por fila, lo que permite confirmar que el servidor ejecuta código inyectado. |

**Cómo ejecutarlo:** abra el script en MySQL Workbench (o desde la consola de MySQL) y ejecútelo completo. La consulta 3 requiere que exista la tabla `productos` en `productosdb`.

**Evidencia:**

![Resultado del Problema 1](docs/img/problema1.png)

---

## Problema 2: Cadenas (armando INSERT / UPDATE) y consultas parametrizadas

**Carpeta:** `Diccionarios/PrubeaFuncionies/`

Un `Dictionary<string, object>` guarda los datos de un producto (`Nombre`, `Precio`, `Cantidad`). A partir de sus claves, el programa arma las sentencias SQL con manipulación de cadenas:

- **Cláusula `SET`** para un `UPDATE`: `Campo = @Campo` por cada clave, unidas con `string.Join`.
- **Columnas y placeholders** para un `INSERT`: la lista de columnas y la lista de parámetros `@Campo`.

Los valores nunca se concatenan dentro del SQL; viajan aparte como parámetros. Así se evita la inyección SQL que se demostró en el Problema 1.

**Salida esperada:**

```text
--- Contenido del Diccionario ---
Clave: Nombre | Valor: Laptop HP Envy
Clave: Precio | Valor: 850.99
Clave: Cantidad | Valor: 15
---------------------------------

Cláusula SET generada: Nombre = @Nombre, Precio = @Precio, Cantidad = @Cantidad
la cadena sql es: INSERT INTO productos (Nombre, Precio, Cantidad) VALUES (@Nombre, @Precio, @Cantidad)
```

**Evidencia:**
<img width="1232" height="83" alt="image" src="https://github.com/user-attachments/assets/c5b949b7-5522-48fb-b51c-51bc92643df0" />


![Resultado del Problema 2](docs/img/problema2.png)

---

## Problema 3: Métodos sobrecargados

**Carpeta:** `SobreCargados/SobreCargados/`

La clase `Operaciones` define dos métodos `Cuadrado` con el mismo nombre y distinta firma:

| Firma | Retorna |
|---|---|
| `Cuadrado(int valorInt)` | `int` |
| `Cuadrado(double valorDouble)` | `double` |

El compilador elige la sobrecarga según el tipo del argumento: `Cuadrado(5)` usa la versión `int` y `Cuadrado(4.5)` usa la versión `double`.

**Salida esperada:**

```text
Se llamó a Cuadrado con argumento int: 5
Resultado entero: 25

Se llamó a Cuadrado con argumento double: 4.5
Resultado double: 20.25
```

**Evidencia:**
<img width="561" height="162" alt="image" src="https://github.com/user-attachments/assets/f1bec343-8868-4ae0-bc16-ed38bbe9f17a" />


![Resultado del Problema 3](docs/img/problema3.png)

---

## Problema 4: Recursividad (Factorial)

**Carpeta:** `Factorial/Factorial/Factorial/`

El método recursivo `FactorialMetodo(long numero)` calcula n!:

- **Caso base:** si `numero <= 1` retorna `1`. Detiene la recursión y evita el desbordamiento de pila (*StackOverflow*).
- **Paso recursivo:** `numero * FactorialMetodo(numero - 1)`.

El programa imprime el factorial de 0 a 10.

**Salida esperada:**

```text
0 = 1
1 = 1
2 = 2
3 = 6
4 = 24
5 = 120
6 = 720
7 = 5040
8 = 40320
9 = 362880
10 = 3628800
```

**Evidencia:**
<img width="411" height="260" alt="image" src="https://github.com/user-attachments/assets/77bfb24f-ee84-4609-bd7a-390d5e59382b" />


![Resultado del Problema 4](docs/img/problema4.png)

---

## Problema 5: Frecuencias

**Carpeta:** `Frecuencias/Frecuencias/Frecuencias/`

Simula 6000 tiros de un dado con `Random.Next(1, 7)` y cuenta cuántas veces sale cada cara con un contador por valor y una estructura `switch`. Al final imprime la tabla de frecuencias.

Los valores cambian en cada ejecución porque son aleatorios. Lo que siempre se cumple es que **las seis frecuencias suman 6000** y que cada una queda cerca de 1000.

**Formato de la salida:**

```text
Cara     Frecuencia
1        ...
2        ...
3        ...
4        ...
5        ...
6        ...
```

**Evidencia:**
<img width="268" height="182" alt="image" src="https://github.com/user-attachments/assets/dc90b805-1d2e-48ab-8a00-61afd642e925" />

![Resultado del Problema 5](docs/img/problema5.png)

---

## Rúbrica de evaluación

| Criterio | Puntaje |
|---|---|
| Puntualidad | 15% |
| Problema 1. Consultas SQL (3) | 10% |
| Problema 2. Cadenas (armando Update / Insert), consultas parametrizadas | 10% |
| Problema 3. Métodos sobrecargados | 15% |
| Problema 4. Recursividad (factorial) | 10% |
| Problema 5. Frecuencia | 10% |
| Repositorio | 15% |
| README.md con imágenes por problema | 15% |

---

<div align="center">

Universidad Tecnológica de Panamá · Herramientas de la Programación Aplicada III (.NET) · Grupo 1IL133 · Entregado el _[fecha de entrega]_

</div>
