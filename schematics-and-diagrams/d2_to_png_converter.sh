#!/bin/bash

# Paths to the input and output directories
input_folder="./input-d2-files"
output_folder="./output-png-files"

# Ensure the output folder exists
mkdir -p "$output_folder"

# Loop through all .d2 files in the input folder
for input_file in "$input_folder"/*.d2; do
    # Extract the filename without extension
    filename=$(basename "$input_file" .d2)
    # Define the output file path
    output_file="$output_folder/$filename.png"

    # Command to convert D2 to PNG
    # Replace 'd2' with the actual command if different
    d2 "$input_file" "$output_file"

    # Check if the conversion was successful
    if [ $? -eq 0 ]; then
    echo "Converted $input_file to $output_file"
    else
    echo "Failed to convert $input_file"
    fi
done
