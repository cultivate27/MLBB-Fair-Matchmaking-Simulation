# MLBB-Fair-Matchmaking-Simulation
A C# CAPSTONE PROJECT by Raziq Danish
_(Currently the project only supports Bahasa Indonesia)._

Simulasi matchmaking game Mobile Legends: Bang Bang yang adil dalam bahasa C#

## Panduan Penggunaan
### Instalasi
1. **Clone Repository:**
   ```bash
   git clone https://github.com/cultivate27/MLBB-Fair-Matchmaking-Simulation.git

2. **Go to project directory**
   ```bash
   cd MLBB-Fair-Matchmaking-Simulation

### Menjalankan Program
1. **Build Project**
   ```bash
   dotnet build

2. **Execute Program**
   ```bash
   dotnet run
   ```
   or

   ```bash
   dotnet run --project {downloadpath}\MLBB-Fair-Matchmaking-Simulation\Matchmaking\Matchmaking.csproj
   ```

## Contoh Penggunaan
   ```bash
   Player - 23 (Slot 1)
   Debug Player Identificator: 1
   Midlaner 32 Match

   Player - 2 (Slot 2)
   Debug Player Identificator: 3
   Roamer 32 Match
   
   Player - 12 (Slot 3)
   Debug Player Identificator: 4
   Jungler 23 Match
   
   Player - 7 (Slot 4)
   Debug Player Identificator: 2
   Explaner 33 Match
   
   Player - 10 (Slot 5)
   Debug Player Identificator: 5
   Goldlaner 27 Match
   
   Sisa player yang belum mendapatkan pasangan dan akan melanjutkan matchmaking: 18
   
   Ingin mengulang matchmaking? [y] / [n]
   ```

### Memasukkan input
Input pada program bukan termasuk Case Sensitive, Anda dapat memasukkan `Y` atau `y`.

> Memasukkan input `Y` atau `y` akan melanjutkan pengacakan matchmaking.
> Memasukkan input `N` atau `n` akan mengakhiri program.
> Memasukkan selain input `Y` atau `y` dan `N` atau `n` akan mengulang konfirmasi pengulangan.

## Cara Kerja
Ketika program baru dijalankan, metode `Start();` akan dieksekusi. Memulai pembuatan beberapa objek player secara acak dan mengisi nilai pada variabel `mid`, `exp`, `roam`, `jungle`, `gold` secara acak dari skala 1 sampai 40 (match terakhir tertinggi yang dapat ditampilkan sekitar 40). Dibalik itu terdapat variabel `public int identificator` sebagai pengidentifikasi role tiap objek dan variabel `public int order` sebagai urutan dari sebaran objek player yang telah dibuat sebelumnya.

Di dalam kelas Player terdapat metode `Highest();` yang akan langsung dijalankan ketika objek dibuat. Metode `theHighest` akan langsung menghitung match terbesar dari nilai pengacakan variabel role antara `mid`, `exp`, `roam`, `jungle`, `gold`. Mengambil match terbesar dari beberapa variabel role akan menentukan role yang paling dikuasai.

Setelah perhitungan masing-masing role paling dikuasai objek pastinya akan terdapat beberapa objek dengan role paling dikuasai yang sama. Oleh karena itu, dari beberapa objek dengan role paling dikuasai yang sama ini akan dipilih salah satunya secara acak. Kemudian hanya akan bersisa 5 objek dengan role paling dikuasai saja. Beberapa objek tersebut akan memiliki pasangannya membentuk 1 sampai 5 secara tidak berurutan.

Terakhir, setelah mendapatkan 5 pasangan maka akan ditampilkan ke konsol. Sebelum ditampilkan ke konsol, variabel `public int identificator` akan digunakan untuk menentukan role paling dikuasai tiap objek dengan aturan:

   ```csharp
   // Midlane = 1
   // Explane = 2
   // Roam = 3
   // Jungle = 4
   // Goldlane = 5
   ```

 dan variabel `public int order` akan digunakan untuk menampilkan urutan objek setelah pembuatan objek tersebut terjadi.

## LICENSE
This project is licensed under the [MIT License](LICENSE).
