# Joost reports

`Joost` is a sql database. It is maintained on a different computer. With backup and restore can the application developed.

## Restore database error

Every morning is a backup created on a `OneDrive` folder. Restoring the backup file I got a access error.

Copying the file from a `OneDrive` to another folder was working workaround.

After the restore must the `JournalDbContext` read again.

## `ListView`



``` C#
<ListView ItemsSource="{Binding Journals}"
          Height="200">
  <ListView.View>
    <GridView>
      <GridViewColumn Header="Start"
                      DisplayMemberBinding="{Binding DTStart, StringFormat=yyyy-MM-dd HH:mm}"/>
      <GridViewColumn Header="Event"
                      DisplayMemberBinding="{Binding Event}"/>
      <GridViewColumn Header="Message"
                      DisplayMemberBinding="{Binding Message}"/>
    </GridView>
```

