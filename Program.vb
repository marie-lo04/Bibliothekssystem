Imports System

''' <summary>
''' Hauptmodul für das Bibliothekssystem - Projekt Teil I
''' </summary>
Module Module1

    ' Strukturen bündeln zusammengehörige Daten (z.B. alle Infos zu einem Buch)
    Structure Buch
        Dim ISBN As String
        Dim Titel As String
        Dim Autor As String
        Dim Status As String
    End Structure

    Structure Benutzer
        Dim ID As String
        Dim Name As String
    End Structure

    Sub Main()
        ' Testdaten als lange Zeichenkette (String), wie im PDF gefordert
        Dim libraryTestData As String = "978-3-16-148410-0; Einführung in die Informatik; Müller; verfügbar|" &
                                         "978-0-13-110362-7; Programmieren mit VB.NET; Schneider; verfügbar |" &
                                         "978-3-540-69006-6; Grundlagen der Softwaretechnik; Meier; ausgeliehen |" &
                                         "978-3-642-05445-3; Datenstrukturen und Algorithmen; Klein; verfügbar"

        Dim usrTestData As String = "U001; Max Mustermann |U002; Erika Musterfrau|U003; Hans Meier |U004; Laura Schmidt"

        Dim auswahl As String = ""

        ' Die Schleife sorgt dafür, dass das Menü nach jeder Aktion neu erscheint
        Do
            Console.Clear() ' Macht den Bildschirm für das Menü sauber
            Console.WriteLine("--- DHBW Bibliothekssystem ---")
            Console.WriteLine("1: Neuen Benutzer anlegen")
            Console.WriteLine("2: Alle Bücher anzeigen")
            Console.WriteLine("3: Alle Benutzer anzeigen")
            Console.WriteLine("x: Programm beenden")
            Console.Write("Auswahl: ")

            auswahl = Console.ReadLine().ToLower()

            ' Prüfung der Eingabe mit If-ElseIf
            If auswahl = "1" Then
                ' Platzhalter für die spätere Logik in Teil II
                Console.WriteLine("Funktion: Neuen Benutzer anlegen ausgewählt.")

            ElseIf auswahl = "2" Then
                ' Zeigt die Bücherliste an
                Console.WriteLine("Bücher im System:")
                Console.WriteLine("-----------------")
                ' Teilt den langen String beim Trennzeichen '|' in einzelne Zeilen
                Dim buecher() As String = libraryTestData.Split("|"c)
                For Each b In buecher
                    Console.WriteLine(b.Trim()) ' Trim entfernt Leerzeichen am Rand
                Next

            ElseIf auswahl = "3" Then
                ' Zeigt die Benutzerliste an
                Console.WriteLine("Registrierte Benutzer:")
                Console.WriteLine("----------------------")
                ' Teilt den String beim Trennzeichen '|'
                Dim nutzer() As String = usrTestData.Split("|"c)
                For Each n In nutzer
                    Console.WriteLine(n.Trim())
                Next

            ElseIf auswahl = "x" Then
                Console.WriteLine("Das Programm wird jetzt beendet.")

            Else
                ' Rückmeldung bei falscher Taste
                Console.WriteLine("Ungültige Eingabe! Bitte wählen Sie 1, 2, 3 oder x.")
            End If

            ' Verhindert, dass das Menü sofort neu lädt, damit man das Ergebnis lesen kann
            If auswahl <> "x" Then
                Console.WriteLine(vbCrLf & "Drücken Sie eine Taste, um zum Menü zurückzukehren...")
                Console.ReadKey()
            End If

        Loop While auswahl <> "x" ' Beendet die Schleife, wenn 'x' eingegeben wurde
    End Sub
End Module