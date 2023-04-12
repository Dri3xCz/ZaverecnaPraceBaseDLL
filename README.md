# ZaverecnaPraceBaseDLL

### Link na EXAMPLE APP - https://github.com/Dri3xCz/ZaverecnaPraceExampleApp
---

### Tento repozitář obsahuje:
- Source code pro DLL, které budete používát k vytvoření podaplikací pro hlavní aplikaci závěrečné práce
- Link na example aplikaci, která implementuje všechny důležité prvky z dll
- Samotné DLL v realeasech
- Readme s informacmei

---

## Co je to DLL soubor?
- DLL soubor (dynamic-link libary) je knihovna tříd obsahující kompilovaný kód aplikace.
- Umožnujě vám pracovat s jinou aplikací i když nemáte source code ve vaší aplikaci.

## Proč tento DLL soubor používáme?
- Potřebuji konzistenci mezi 15 různými aplikacemi, DLL soubor zajístí podobnou strukturu aplikace bez toho, abyste vy se mezi sebou museli domlouvat

## Jak vytvořím DLL soubor?
- I vy budete muset pro mě vytvořit DLL soubor. Ve visual studiu toho docílíte tak, že půjdete na vlastnosti projektu a první vlastnost *Typ výstupu* změníte na *Knihovna tříd*


---

# Vysvětlení source kódu:
#### Source kód obsahuje 3 hlavní soubory:
- IGameForm.cs
- IMainForm.cs
- FakeForm.cs

#### Začneme u IGameForm neboť je pro vás nejduležitější:
```C#
    public interface IGameForm
    {
        void StartGame();
        
        void EndGame();

        void Restart();

        Form InitForm(IMainForm mainForm);

    }
```
#### Pro ty co neví co je interface:
- Interface definuje kontrakt, jakákoliv struktura nebo classa, která interface implementuje musí respektovat tento interface.
- Tato struktura poté musí implementovat metody určené interfací.
- Metody jsou defaultně public.

#### Co dělá tato konrétní interface?
- Nutí vás implementovat metodu Startgame, EndGame a Restart. Každá hra by přece jenom měla mít začátek, konec a způsob hru restartovat. 
- Dále, pro mě důležitější metoda: Form InitForm(IMainForm mainForm);
- Bude sloužit jako entrypoint pro vaší aplikaci - tato metoda vrací form, form který se vrátí z této metody já ve své aplikaci budu zoobrazovat jako první.
- Pokud vaše aplikace bude mít jen jeden form stačí vrátit váš form (return this).
- Metoda také má parametr typu jiné interface IMainForm, o té ale později. Co je důležité ovšem je, že musíte tento parametr uložit někam do paměti.

#### Narazli jsem na IMainForm, co dělá ten?
```C#
    public interface IMainForm
    {
        void SendData(char c);
    }
```
##### Poněkud jednoduší interface s jednou metodou. Tato metoda slouží k posílaní vámi zvoleného charakteru do hlavní aplikace. Implementace této metody vás nezajímá, ovšem podmínka pro vaší aplikaci je, že musíte na konci vaší hry tuto metodu zavolat. Počítejte s tím, že váš form se touto metodou zavře, takže by to měla být poslední věc co váš form udělá.

#### Jako poslední tu je FakeForm:
```C#
    public partial class FakeForm : Form, IMainForm
    {
        public FakeForm()
        {
            InitializeComponent();
        }

        public void SendData(char c)
        {
            MessageBox.Show("Poslal se charakter " + c);
        }
    }
```
#### Proč jménem zrovna FakeForm?
- Form implementuje interface IMainForm.
- Tento form bude pro vaší aplikaci předstírat, že je hlavní formulář závěrečné aplikace. 
- Tento form slouží čistě k debugování vaší aplikace, díky FakeFormu můžete zjistit, jestli vaše aplikace funguje správně.
- Jelikož slouží jenom k debugování tak implementuje jen to, co po něm interface chce, a to právě void SendData(char c);

---

# Zadání pro vás:
- Stáhnout dll v releasu
- Prohlídnout si example appku
- Vytvořit projekt
- Vložit dll do projektu
- Nastavit závislost na tomto dll
- Udělat z vašeho hlavního Formu IGameForm
- Implementovat InitForm() tak, aby zoobrazoval form, který chcete jako první. V případě, že máte pouze jeden form, stačí return this;
- Uložit si IMainForm z InitFormu do proměnné
- Zakončit vaší aplikaci v metodě EndGame() a zde jako poslední řáděk kódu zavolat metodu (IMainForm).SendData('#')  # - Vámi zvolený charakter

# Need help?
- Jsme skoro 24/7 na discordu
- Oslov mě ve škole
- Absolutně nebudu dělat celou práci za vás, to nepřichází v úvahu, ovšem vím, že někteří lidé nemají programovaní rádi tak jako já. Klidně s vámi celý source kód projedu individuálně a vysvětlím nejlépe jak dokážu.
