**DirectoryBuilder**
    Input a directory of a folder into the parameters, nothing would happen if the file already exists, but creates it when the folder(s) doesn't exist.

**BuildForFile**
    Input a directory of a file into the parameters, nothing would happen if the file already exists, but creates it when the folder(s) or file doesn't exist. Does not return anything as its assumed to be a success, but will most likely throw a access violation exception due to permissions.

**RemoveLingeringSlashes** - *internal, not public*
    Primarily used by above to avoid errors, feel free to do something like @"c:\Users\", which it will remove it into @"c:\Users