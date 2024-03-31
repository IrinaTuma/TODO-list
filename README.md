# Description
>Suomeksi on [täällä](#finnish)

## Explanation of how the application works and what it is used for

The application is a to-do list organized into 4 groups according to the Eisenhower Matrix (a time management method that helps prioritize tasks: doing what's important and not wasting time on unnecessary things).

In the app, tasks can be added to one of four lists: important and urgent, important and not urgent, unimportant and urgent, unimportant and not urgent. Users can also mark tasks as completed/uncompleted and delete unnecessary tasks. User data is stored in an Access database. The application is intentionally designed to look minimalist to make interaction with it as fast and simple as possible.

<br>
<br>

## Flowchart of the application

<img src="https://github.com/IrinaTuma/TODO-list/assets/94453230/8ea334c9-1f41-449b-84eb-0f3dc5e4b8a4" width="800">


<br>
<br>

## How to use the application
**This is how the application looks when there are no entries (for example, upon initial opening).**

<img src="https://github.com/IrinaTuma/TODO-list/assets/94453230/e92eac13-547b-4bed-a6b3-295f69199b9d" width="500">

<br>
<br>

**Let's see how the application works. The areas to pay attention to in the screenshots are highlighted with a red border.**
<be>
<br>
### Adding a new task:

You need to write the task in the input field.

<img src="https://github.com/IrinaTuma/TODO-list/assets/94453230/ef7cb40e-eb81-46af-99a9-57edbeb944f0" width="500">

<br>
<br>

Then you need to click on the button - a colored square of the same color as the field where you need to add the task. After that, the task will appear in this field.

<img src="https://github.com/IrinaTuma/TODO-list/assets/94453230/9a0c34e2-1a2b-463f-ae0e-c2971fec2907" width="500">

<br>
<br>

This is what the application looks like with tasks added to it. If the task list does not fit on the screen, a scroll bar appears on the side.

<img src="https://github.com/IrinaTuma/TODO-list/assets/94453230/d41c6615-e2d6-48ae-8cdd-ffc69b249e9f" width="500">

<br>
<br>

### Completed / incomplete task

To mark a task as completed or incomplete, you need to click on the checkbox next to it.

<img src="https://github.com/IrinaTuma/TODO-list/assets/94453230/6c03ca87-cf64-4303-8e47-7ac6d7860c1a" width="500">

<br>
<br>

The checkbox value will toggle accordingly. If the task is marked as completed, it moves to the bottom of the task list. When the checkbox is changed to the "inactive" state, the task moves back to its original position.

<img src="https://github.com/IrinaTuma/TODO-list/assets/94453230/740adea7-b3d5-4e25-ab16-aeacd24dd82d" width="500">

<br>
<br>

### Deleting a task

To delete a task, you need to select the task by clicking on it with the mouse.

<img src="https://github.com/IrinaTuma/TODO-list/assets/94453230/d4c435b2-cf45-453b-97ee-b02e85f29bff" width="500">

<br>
<br>

Then you need to click on the button with a cross (X).

<img src="https://github.com/IrinaTuma/TODO-list/assets/94453230/543d9091-bb2a-42b7-9d0c-5a57f83c6235" width="500">

<br>
<br>

After that, a notification will appear stating that the task has been deleted. You need to click "OK".

<img src="https://github.com/IrinaTuma/TODO-list/assets/94453230/ca6aad59-333f-461b-a783-a054fbc2c905" width="500">

<br>
<br>

## Key points of the code

In my application, an Access database is used, and the interaction of the application with it is the main focus in the code.

### Function for adding data to the database

First, this method checks that the `textBoxTitle` text field is not empty and its length does not exceed 55 characters. If the field is empty or its length exceeds the maximum value, an error message is displayed.

Then the code reads the text from the `textBoxTitle` text field (task title), creates a connection string to the database, and forms a query to add data to the table specifying the task title.

Next, the query is executed on the database. If the operation is successful, the data is cleared from the text field, the content of the `DataGridView` is updated, and a message indicating successful data addition is displayed. If an error occurs, an error message with a description of the error is displayed.

```C#
private void AddFunction(DataGridView dataGridView, string databaseTable)
{
    // Set the max length for TextBox
    textBoxTitle.MaxLength = 55;

    // Check that Text Box is not empty and not longer that 50 symbols
    if (string.IsNullOrWhiteSpace(textBoxTitle.Text) || textBoxTitle.Text.Length > textBoxTitle.MaxLength)
    {
        MessageBox.Show("Kirjoita tietoja tekstilaatikkoon enintään 55 merkkiä!", "Huomio"); //Message: Enter data in the TextBox up to 55 characters!
        return;
    }


    //Read the data
    string title = textBoxTitle.Text;

    //Create the connection
    string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb"; //String for connection
    OleDbConnection dbConnection = new OleDbConnection(connectionString); //Creating of connection

    //Running a database query
    string query = "INSERT INTO " + databaseTable + " (Title) VALUES (@title)"; //srting of query
    OleDbCommand dbCommand = new OleDbCommand(query, dbConnection); //command
    dbCommand.Parameters.AddWithValue("@title", title);



    //Create a query
    try
    {
        dbConnection.Open(); //Open connection
        int rowsAffected = dbCommand.ExecuteNonQuery();


        //Close the connection with DataBase
        dbConnection.Close();

        //Clean the text box
        textBoxTitle.Clear();


        dataGridView.Rows.Clear();
        TableLoad(dataGridView, databaseTable);//Load DataBase

        //Test message:
        //MessageBox.Show("Data was added", "Attention");
    }
    catch (Exception ex)
    {
        MessageBox.Show("Kyselyn virhe: " + ex.Message, "Virhe!"); //Message: "Mistake of the query: "
    }

}

```

<br>

### Deletion from the database

This section of the code contains the `DeleteFunction` function, which is responsible for deleting selected items from the database and the `DataGridView` table. This function iterates through all selected rows in the `DataGridView` table and for each row, it deletes the corresponding record from the database. After deleting the row from the database, the number of affected rows is checked: if the deletion is successful, the corresponding row is also removed from the `DataGridView`, and in the case of a single deletion, a message indicating successful deletion is displayed.

```C#
private void DeleteFunction(DataGridView dataGridView, string baseName)
{

    // To do the same for each chosen row
    foreach (DataGridViewRow row in dataGridView.SelectedRows)
    {

        // Recieve the data from the cell
        string title = row.Cells[1].Value.ToString();

        // Create the connection with DataBase
        string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";
        using (OleDbConnection dbConnection = new OleDbConnection(connectionString))
        {
            string query = "DELETE FROM " + baseName + " WHERE Title = @title"; // query of deletion
            using (OleDbCommand dbCommand = new OleDbCommand(query, dbConnection))
            {
                dbCommand.Parameters.AddWithValue("@title", title);

                try
                {
                    dbConnection.Open();
                    int rowsAffected = dbCommand.ExecuteNonQuery();
                    dbConnection.Close();

                    if (rowsAffected > 0)
                    {

                        if (dataGridView.SelectedRows.Count == 1)
                        {
                            // Delete the string from DataGridView
                            dataGridView.Rows.Remove(row);
                            dataGridView.ClearSelection();
                            MessageBox.Show("Valitut rivit poistettu", "Menestys"); //Message: Select rows to delete
                        }
                        else
                        {
                            // Delete the string from DataGridView
                            dataGridView.Rows.Remove(row);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Tietoja ei poisteta", "Huomio"); //Message: No data deleted
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kyselyn virhe: " + ex.Message, "Virhe!"); //Message: "Mistake of the query: "
                }
            }
        }
    }

}

```

<br>

### Function for loading data from the database into `DataGridView` tables

This code performs the following actions:

+ In the `DatabaseLoad()` method, the `TableLoad()` method is called for each of the `DataGridView` tables, passing the table name in the database.
+ `The TableLoad()` method executes a query to select data from the database and adds them to the corresponding `DataGridView` table.
+ After loading the data, sorting is done by the "Check" column using the `IIF` function.
+ Additionally, the color is changed for headers with a set flag, and row selection in the `DataGridView` is cleared.

```C#
//LOAD
//Loading of Database
private void DatabaseLoad()
{

    TableLoad(dataGridImportantUrgent, "baseImportantUrgent");
    TableLoad(dataGridImportantNotUrgent, "baseImportantNotUrgent");
    TableLoad(dataGridNotImportantUrgent, "baseNotImportantUrgent");
    TableLoad(dataGridNotImportantNotUrgent, "baseNotImportantNotUrgent");

}


//FUNCTION: Loading of Database and sorting it by "Check" column
private void TableLoad(DataGridView dataGridView, string databaseTable)
{
    string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb"; //String for connection
    string query = "SELECT * FROM " + databaseTable + " ORDER BY IIF(Check = true, 1, 0)"; //string of query with sorting by "Check"

    using (OleDbConnection dbConnection = new OleDbConnection(connectionString))
    {
        OleDbCommand dbCommand = new OleDbCommand(query, dbConnection); //command

        try
        {
            dbConnection.Open(); //Open connection
            OleDbDataReader dbReader = dbCommand.ExecuteReader(); //Read data


            if (dbReader.HasRows)
            {
                while (dbReader.Read()) //while there are still rows to add
                {
                    dataGridView.Rows.Add(dbReader["ID"], dbReader["Title"], dbReader["Check"]); //Add Data from Database in DataGridView

                    //changing the color for titles with checkbox = true, clearing the selection
                    if (dataGridView.Name == "dataGridImportantUrgent")
                    {
                        dataGridImportantUrgent.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridImportantUrgent_CellFormatting); //this function changes the color for titles with checkbox = true
                    }
                    else if (dataGridView.Name == "dataGridNotImportantUrgent")
                    {
                        dataGridNotImportantUrgent.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridNotImportantUrgent_CellFormatting); //this function changes the color for titles with checkbox = true
                    }
                    else if (dataGridView.Name == "dataGridImportantNotUrgent")
                    {
                        dataGridImportantNotUrgent.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridImportantNotUrgent_CellFormatting); //this function changes the color for titles with checkbox = true
                    }
                    else if (dataGridView.Name == "dataGridNotImportantNotUrgent")
                    {
                        dataGridNotImportantNotUrgent.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridNotImportantNotUrgent_CellFormatting); //this function changes the color for titles with checkbox = true
                    }

                    dataGridView.ClearSelection();


                }
            }


            //Close the connection
            dbReader.Close();
            dbConnection.Close();

        }
        catch (Exception ex)
        {
            MessageBox.Show("Kyselyn virhe: " + ex.Message, "Virhe"); //Message: "Mistake of the query: "
        }

    }
}

```

<br>

### Checkbox Function

This code snippet handles the click event on a cell with a checkbox in the DataGridView table and updates the checkbox value in the database.
This `CheckBoxCellClicked()` method performs the following steps:

+ Checks if the event occurred in the checkbox column `(ColumnIndex == 2)` and that the click did not occur in the table header `(RowIndex >= 0)`.
+ Retrieves the checkbox value from the cell.
+ Determines the new checkbox value (inverts the current value).
+ Forms and executes a query to update the checkbox value in the database.
+ Updates the data in the `DataGridView` after successful database update.
+ Displays an error message in case of an exception.

```C#
//FUNCTION for Checkboxes
private void CheckBoxCellClicked(DataGridViewCellEventArgs e, DataGridView dataGridView, string tableName)
{
    if (e.ColumnIndex == 2 && e.RowIndex >= 0)
    {
        DataGridViewCheckBoxCell cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;

        if (cell != null)
        {
            bool isChecked = !(bool)cell.Value;

            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";
            using (OleDbConnection dbConnection = new OleDbConnection(connectionString))
            {
                string updateQuery = $"UPDATE {tableName} SET [Check] = (@isChecked) WHERE ID = (@id)";
                using (OleDbCommand updateCommand = new OleDbCommand(updateQuery, dbConnection))
                {
                    updateCommand.Parameters.AddWithValue("@isChecked", isChecked);
                    updateCommand.Parameters.AddWithValue("@id", dataGridView.Rows[e.RowIndex].Cells[0].Value);

                    try
                    {
                        dbConnection.Open();
                        int rowsAffected = updateCommand.ExecuteNonQuery();
                        dbConnection.Close();

                        if (rowsAffected == 1)
                        {
                            dataGridView.Rows.Clear();
                            TableLoad(dataGridView, tableName);

                            //Test message
                            //MessageBox.Show("Database updated!", "Success");
                        }
                        else
                        {
                            MessageBox.Show("Ei päivitettyjä rivejä!", "Virhe"); //Message: No rows updated!
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Tietokannan päivitysvirhe: " + ex.Message, "Virhe"); //Message: "Database update error: "
                    }
                }
            }
        }
    }
}

```

<br>

## Ideas for further development

1. Add a "Clear Lists" button to quickly delete all tasks from the application. Additionally, provide the ability to select multiple tasks for deletion simultaneously.

2. Introduce a deadline for tasks (date) and sort the tasks in the lists according to the deadline.

3. Currently, the application uses standard elements, and the appearance of some of them cannot be significantly altered using standard methods. However, consider exploring the option of modifying them using third-party libraries/components.

<br>

# <a id="finnish">In Finnish (Suomeksi)</a>
## Sovelluksen toimintaperiaatteen ja käyttötarkoituksen selitys

Sovellus on tehtäväluettelo, joka on jaettu neljään ryhmään Eisenhowerin matriisin mukaisesti (aikanhallintamenetelmä, joka auttaa priorisoimaan tehtäviä: tärkeiden asioiden tekeminen ja ajan tuhlaamisen välttäminen tarpeettomiin asioihin).

Sovelluksessa tehtävät voidaan lisätä yhteen neljästä luettelosta: tärkeää ja kiireellistä, tärkeää ja ei kiireellistä, ei tärkeää ja kiireellistä, ei tärkeää ja ei kiireellistä. Käyttäjät voivat myös merkitä tehtävät suoritetuiksi/tekemättömiksi ja poistaa tarpeettomat tehtävät. Käyttäjän tiedot tallennetaan Access-tietokantaan. Sovellus on tarkoituksella suunniteltu minimalistiseksi, jotta sen käyttö olisi mahdollisimman nopeaa ja yksinkertaista.
<br>
<br>

## Vuokaavio sovelluksesta

<img src="https://github.com/IrinaTuma/TODO-list/assets/94453230/25cff9b4-8f15-465e-afec-1b0ceca32c57" width="800">

<br>
<br>

## Kuinka käyttää sovellusta
**Tällainen sovellus näyttää, kun siinä ei ole merkintöjä (esimerkiksi avattaessa alun perin).**

<img src="https://github.com/IrinaTuma/TODO-list/assets/94453230/e92eac13-547b-4bed-a6b3-295f69199b9d" width="500">

<br>
<br>

**Katsotaan, miten sovellus toimii. Kuvakaappauksissa huomioitavat alueet on korostettu punaisella reunuksella.**
<be>
<br>
### Uuden tehtävän lisääminen:

Sinun täytyy kirjoittaa tehtävä syöttökenttään.

<img src="https://github.com/IrinaTuma/TODO-list/assets/94453230/ef7cb40e-eb81-46af-99a9-57edbeb944f0" width="500">

<br>
<br>

Sen jälkeen sinun täytyy klikata painiketta - värillistä neliötä, joka on samanvärinen kuin kenttä, johon haluat lisätä tehtävän. Tämän jälkeen tehtävä ilmestyy tähän kenttään.

<img src="https://github.com/IrinaTuma/TODO-list/assets/94453230/9a0c34e2-1a2b-463f-ae0e-c2971fec2907" width="500">

<br>
<br>

Tässä on, miltä sovellus näyttää, kun siihen on lisätty tehtäviä. Jos tehtäväluettelo ei mahdu näytölle, sivulle ilmestyy vierityspalkki.

<img src="https://github.com/IrinaTuma/TODO-list/assets/94453230/d41c6615-e2d6-48ae-8cdd-ffc69b249e9f" width="500">

<br>
<br>

### Valmis / keskeneräinen tehtävä

Merkitäksesi tehtävän valmiiksi tai keskeneräiseksi, sinun tulee klikata sen vieressä olevaa valintaruutua.

<img src="https://github.com/IrinaTuma/TODO-list/assets/94453230/6c03ca87-cf64-4303-8e47-7ac6d7860c1a" width="500">

<br>
<br>

Valintaruudun arvo vaihtuu sen mukaisesti. Jos tehtävä on merkitty valmiiksi, se siirtyy tehtäväluettelon alaosaan. Kun valintaruutu muutetaan "epäaktiiviseen" tilaan, tehtävä palaa alkuperäiseen sijaintiinsa.

<img src="https://github.com/IrinaTuma/TODO-list/assets/94453230/740adea7-b3d5-4e25-ab16-aeacd24dd82d" width="500">

<br>
<br>

### Tehtävän poistaminen

Tehtävän poistamiseksi sinun täytyy valita tehtävä klikkaamalla sitä hiirellä.

<img src="https://github.com/IrinaTuma/TODO-list/assets/94453230/d4c435b2-cf45-453b-97ee-b02e85f29bff" width="500">

<br>
<br>

Sen jälkeen täytyy klikata rastin (X) painiketta.

<img src="https://github.com/IrinaTuma/TODO-list/assets/94453230/543d9091-bb2a-42b7-9d0c-5a57f83c6235" width="500">

<br>
<br>

Tämän jälkeen ilmoitus ilmestyy, jossa kerrotaan, että tehtävä on poistettu. Sinun tulee klikata "OK".

<img src="https://github.com/IrinaTuma/TODO-list/assets/94453230/ca6aad59-333f-461b-a783-a054fbc2c905" width="500">

<br>
<br>

## Pääkohdat koodista

Sovelluksessani käytetään Access-tietokantaa, ja sovelluksen vuorovaikutus sen kanssa on koodissa pääpainopiste.

### Funktio tietojen lisäämiseksi tietokantaan

Ensinnäkin, tämä metodi tarkistaa, että `textBoxTitle` -tekstikenttä ei ole tyhjä eikä sen pituus ylitä 55 merkkiä. Jos kenttä on tyhjä tai sen pituus ylittää enimmäisarvon, näytetään virhesanoma.

Sitten koodi lukee tekstin `textBoxTitle` -tekstikentästä (tehtävän otsikko), luo yhteyden tietokantaan ja muodostaa kyselyn datan lisäämiseksi tauluun, määrittäen tehtävän otsikon.

Seuraavaksi kysely suoritetaan tietokannassa. Jos toimenpide onnistuu, tiedot tyhjennetään tekstikentästä, `DataGridView`-sisältö päivitetään ja näytetään viesti onnistuneesta datan lisäyksestä. Jos virhe tapahtuu, näytetään virhesanoma virheen kuvauksella.

```C#
private void AddFunction(DataGridView dataGridView, string databaseTable)
{
    // Set the max length for TextBox
    textBoxTitle.MaxLength = 55;

    // Check that Text Box is not empty and not longer that 50 symbols
    if (string.IsNullOrWhiteSpace(textBoxTitle.Text) || textBoxTitle.Text.Length > textBoxTitle.MaxLength)
    {
        MessageBox.Show("Kirjoita tietoja tekstilaatikkoon enintään 55 merkkiä!", "Huomio"); //Message: Enter data in the TextBox up to 55 characters!
        return;
    }


    //Read the data
    string title = textBoxTitle.Text;

    //Create the connection
    string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb"; //String for connection
    OleDbConnection dbConnection = new OleDbConnection(connectionString); //Creating of connection

    //Running a database query
    string query = "INSERT INTO " + databaseTable + " (Title) VALUES (@title)"; //srting of query
    OleDbCommand dbCommand = new OleDbCommand(query, dbConnection); //command
    dbCommand.Parameters.AddWithValue("@title", title);



    //Create a query
    try
    {
        dbConnection.Open(); //Open connection
        int rowsAffected = dbCommand.ExecuteNonQuery();


        //Close the connection with DataBase
        dbConnection.Close();

        //Clean the text box
        textBoxTitle.Clear();


        dataGridView.Rows.Clear();
        TableLoad(dataGridView, databaseTable);//Load DataBase

        //Test message:
        //MessageBox.Show("Data was added", "Attention");
    }
    catch (Exception ex)
    {
        MessageBox.Show("Kyselyn virhe: " + ex.Message, "Virhe!"); //Message: "Mistake of the query: "
    }

}

```

<br>

### Poisto tietokannasta

Tämä koodin osa sisältää `DeleteFunction`-funktion, joka vastaa valittujen kohteiden poistamisesta tietokannasta ja DataGridView-taulusta. Tämä funktio käy läpi kaikki valitut rivit `DataGridView`-taulussa ja jokaiselle riville se poistaa vastaavan tietueen tietokannasta. Rivin poiston jälkeen tarkistetaan vaikutettujen rivien määrä: jos poisto onnistuu, vastaava rivi poistetaan myös `DataGridView`-taulusta, ja yksittäisen poiston tapauksessa näytetään viesti onnistuneesta poistosta.

```C#
private void DeleteFunction(DataGridView dataGridView, string baseName)
{

    // To do the same for each chosen row
    foreach (DataGridViewRow row in dataGridView.SelectedRows)
    {

        // Recieve the data from the cell
        string title = row.Cells[1].Value.ToString();

        // Create the connection with DataBase
        string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";
        using (OleDbConnection dbConnection = new OleDbConnection(connectionString))
        {
            string query = "DELETE FROM " + baseName + " WHERE Title = @title"; // query of deletion
            using (OleDbCommand dbCommand = new OleDbCommand(query, dbConnection))
            {
                dbCommand.Parameters.AddWithValue("@title", title);

                try
                {
                    dbConnection.Open();
                    int rowsAffected = dbCommand.ExecuteNonQuery();
                    dbConnection.Close();

                    if (rowsAffected > 0)
                    {

                        if (dataGridView.SelectedRows.Count == 1)
                        {
                            // Delete the string from DataGridView
                            dataGridView.Rows.Remove(row);
                            dataGridView.ClearSelection();
                            MessageBox.Show("Valitut rivit poistettu", "Menestys"); //Message: Select rows to delete
                        }
                        else
                        {
                            // Delete the string from DataGridView
                            dataGridView.Rows.Remove(row);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Tietoja ei poisteta", "Huomio"); //Message: No data deleted
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kyselyn virhe: " + ex.Message, "Virhe!"); //Message: "Mistake of the query: "
                }
            }
        }
    }

}

```

<br>

### Funktio tietojen lataamiseksi tietokannasta `DataGridView`-tauluihin

Tämä koodi suorittaa seuraavat toimet:

+`DatabaseLoad()`-metodissa kutsutaan `TableLoad()`-metodia jokaiselle DataGridView-taululle, välittäen taulun nimen tietokannassa.
+`TableLoad()`-metodi suorittaa kyselyn tietojen valitsemiseksi tietokannasta ja lisää ne vastaavaan `DataGridView`-tauluun.
+Tietojen lataamisen jälkeen järjestäminen tehdään "Check" -sarakkeen mukaan käyttäen `IIF`-funktiota.
+Lisäksi väri muutetaan lippua asettaville otsikoille, ja rivi valinta `DataGridView`-taulussa poistetaan.

```C#
//LOAD
//Loading of Database
private void DatabaseLoad()
{

    TableLoad(dataGridImportantUrgent, "baseImportantUrgent");
    TableLoad(dataGridImportantNotUrgent, "baseImportantNotUrgent");
    TableLoad(dataGridNotImportantUrgent, "baseNotImportantUrgent");
    TableLoad(dataGridNotImportantNotUrgent, "baseNotImportantNotUrgent");

}


//FUNCTION: Loading of Database and sorting it by "Check" column
private void TableLoad(DataGridView dataGridView, string databaseTable)
{
    string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb"; //String for connection
    string query = "SELECT * FROM " + databaseTable + " ORDER BY IIF(Check = true, 1, 0)"; //string of query with sorting by "Check"

    using (OleDbConnection dbConnection = new OleDbConnection(connectionString))
    {
        OleDbCommand dbCommand = new OleDbCommand(query, dbConnection); //command

        try
        {
            dbConnection.Open(); //Open connection
            OleDbDataReader dbReader = dbCommand.ExecuteReader(); //Read data


            if (dbReader.HasRows)
            {
                while (dbReader.Read()) //while there are still rows to add
                {
                    dataGridView.Rows.Add(dbReader["ID"], dbReader["Title"], dbReader["Check"]); //Add Data from Database in DataGridView

                    //changing the color for titles with checkbox = true, clearing the selection
                    if (dataGridView.Name == "dataGridImportantUrgent")
                    {
                        dataGridImportantUrgent.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridImportantUrgent_CellFormatting); //this function changes the color for titles with checkbox = true
                    }
                    else if (dataGridView.Name == "dataGridNotImportantUrgent")
                    {
                        dataGridNotImportantUrgent.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridNotImportantUrgent_CellFormatting); //this function changes the color for titles with checkbox = true
                    }
                    else if (dataGridView.Name == "dataGridImportantNotUrgent")
                    {
                        dataGridImportantNotUrgent.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridImportantNotUrgent_CellFormatting); //this function changes the color for titles with checkbox = true
                    }
                    else if (dataGridView.Name == "dataGridNotImportantNotUrgent")
                    {
                        dataGridNotImportantNotUrgent.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridNotImportantNotUrgent_CellFormatting); //this function changes the color for titles with checkbox = true
                    }

                    dataGridView.ClearSelection();


                }
            }


            //Close the connection
            dbReader.Close();
            dbConnection.Close();

        }
        catch (Exception ex)
        {
            MessageBox.Show("Kyselyn virhe: " + ex.Message, "Virhe"); //Message: "Mistake of the query: "
        }

    }
}

```

<br>

### Valintaruudun toiminto

Tämä koodinpätkä käsittelee valintaruudun napsautustapahtumaa DataGridView-taulussa ja päivittää valintaruudun arvon tietokantaan.
Tämä `CheckBoxCellClicked()` -metodi suorittaa seuraavat vaiheet:

+Tarkistaa, tapahtuiko tapahtuma valintaruutusarakkeessa `(ColumnIndex == 2)` ja että napsautus ei tapahtunut taulukon otsikossa `(RowIndex >= 0)`.
+Noutaa valintaruudun arvon solusta.
+Määrittää uuden valintaruudun arvon (kääntää nykyisen arvon).
+Muodostaa ja suorittaa kyselyn valintaruudun arvon päivittämiseksi tietokantaan.
+Päivittää tiedot `DataGridView`-taulussa onnistuneen tietokantapäivityksen jälkeen.
+Näyttää virhesanoman poikkeustapauksessa.

```C#
//FUNCTION for Checkboxes
private void CheckBoxCellClicked(DataGridViewCellEventArgs e, DataGridView dataGridView, string tableName)
{
    if (e.ColumnIndex == 2 && e.RowIndex >= 0)
    {
        DataGridViewCheckBoxCell cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;

        if (cell != null)
        {
            bool isChecked = !(bool)cell.Value;

            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";
            using (OleDbConnection dbConnection = new OleDbConnection(connectionString))
            {
                string updateQuery = $"UPDATE {tableName} SET [Check] = (@isChecked) WHERE ID = (@id)";
                using (OleDbCommand updateCommand = new OleDbCommand(updateQuery, dbConnection))
                {
                    updateCommand.Parameters.AddWithValue("@isChecked", isChecked);
                    updateCommand.Parameters.AddWithValue("@id", dataGridView.Rows[e.RowIndex].Cells[0].Value);

                    try
                    {
                        dbConnection.Open();
                        int rowsAffected = updateCommand.ExecuteNonQuery();
                        dbConnection.Close();

                        if (rowsAffected == 1)
                        {
                            dataGridView.Rows.Clear();
                            TableLoad(dataGridView, tableName);

                            //Test message
                            //MessageBox.Show("Database updated!", "Success");
                        }
                        else
                        {
                            MessageBox.Show("Ei päivitettyjä rivejä!", "Virhe"); //Message: No rows updated!
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Tietokannan päivitysvirhe: " + ex.Message, "Virhe"); //Message: "Database update error: "
                    }
                }
            }
        }
    }
}

```

<br>

## Jatkokehitysideat

1. Lisää "Tyhjennä listat" -painike, jolla voit nopeasti poistaa kaikki tehtävät sovelluksesta. Lisäksi tarjoa mahdollisuus valita useita tehtäviä poistettavaksi samanaikaisesti.

2. Lisää tehtäville määräaika (päivämäärä) ja lajittele tehtävät luetteloissa määräajan mukaan.

3. Tällä hetkellä sovellus käyttää vakioelementtejä, eikä joidenkin niistä ulkonäköä voi merkittävästi muuttaa vakiokeinoin. Kuitenkin harkitse mahdollisuutta muokata niitä käyttämällä kolmannen osapuolen kirjastoja/komponentteja.

<br>
